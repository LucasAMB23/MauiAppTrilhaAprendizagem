using MauiAppTrilhaAprendizagem.Data;
using MauiAppTrilhaAprendizagem.Models;
using System.Runtime.Intrinsics.X86;

namespace MauiAppTrilhaAprendizagem.Views.Aluno
{
    public partial class ProgressoPage : ContentPage
    {
        private readonly DatabaseContext _databaseContext;

        public ProgressoPage(AlunoModel aluno)
        {
            InitializeComponent();
            _databaseContext = new DatabaseContext();
        }


        // Essa função roda sozinha AUTOMATICAMENTE toda vez que a tela abre
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CarregarDadosDoBancoAsync();
        }

        private async Task CarregarDadosDoBancoAsync()
        {
            int idUsuario = Preferences.Default.Get("IdUsuarioLogado", 0);

            if (idUsuario != 0)
            {
                var usuarios = await _databaseContext.GetUsuariosAsync();
                var usuarioBanco = usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                if (usuarioBanco != null)
                {
                    // Pega o texto do banco (Ex: "Trilha dos Números,Trilha das Quantidades")
                    string concluidas = usuarioBanco.TrilhasConcluidas ?? "";

                    var alunoModelReal = new AlunoModel
                    {
                        Nome = usuarioBanco.Nome,
                        PontuacaoTotal = usuarioBanco.PontuacaoTotal,
                        TotalAcertos = usuarioBanco.TotalAcertos,
                        TotalTentativas = usuarioBanco.TotalTentativas,

                        // 🌟 VERIFICA SE O NOME DA TRILHA ESTÁ ESCRITO NO BANCO DE DADOS:
                        TrilhaNumerosConcluida = concluidas.Contains("Trilha dos Números"),
                        TrilhaQuantidadesConcluida = concluidas.Contains("Trilha das Quantidades"),
                        TrilhaCoresFormasConcluida = concluidas.Contains("Trilha das Cores e Formas")
                    };

                    BindingContext = alunoModelReal;
                }
            }
        }
    }
}
