using MauiAppTrilhaAprendizagem.Data;
using MauiAppTrilhaAprendizagem.Models;

namespace MauiAppTrilhaAprendizagem.Views
{
    public partial class RelatoriosPage : ContentPage
    {
        private readonly DatabaseContext _db;

        public RelatoriosPage()
        {
            InitializeComponent();

            _db = new DatabaseContext();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var usuarios = await _db.GetUsuariosAsync();

            var relatorios = usuarios
            .Where(u => u.Perfil == "Aluno")
            .Select(u =>
            {
                int erros = u.TotalTentativas - u.TotalAcertos;

                double taxa =
                 u.TotalTentativas > 0
                 ? (double)u.TotalAcertos / u.TotalTentativas * 100
                 : 0;

                string avaliacao;

                if (u.TotalTentativas == 0)
                {
                    avaliacao =
                    "ℹ Aluno ainda não realizou atividades.";
                }
                else if (taxa >= 80)
                {
                    avaliacao =
                    "✅ Excelente desempenho.\n✅ Domina os conteúdos trabalhados.";
                }
                else if (taxa >= 60)
                {
                    avaliacao =
                    "✅ Bom desempenho.\n⚠ Recomenda-se continuar praticando.";
                }
                else
                {
                    avaliacao =
                    "⚠ Necessita reforço pedagógico.\n⚠ Recomenda-se repetir algumas trilhas.";
                }

                if (taxa >= 80)
                {
                    avaliacao =
                    "✅ Excelente desempenho. Domina os conteúdos trabalhados.";
                }
                else if (taxa >= 60)
                {
                    avaliacao =
                    "✅ Bom desempenho. Recomenda-se continuar praticando.";
                }
                else
                {
                    avaliacao =
                     "⚠ Necessita reforço pedagógico e acompanhamento.";
                }

                return new RelatorioAlunoModel
                {
                    Nome = u.Nome,
                    PontuacaoTotal = u.PontuacaoTotal,
                    TotalAcertos = u.TotalAcertos,
                    TotalTentativas = u.TotalTentativas,
                    TotalErros = erros,
                    TrilhasConcluidas = u.TrilhasConcluidas,
                    TaxaAcerto = Math.Round(taxa, 1),
                    AvaliacaoPedagogica = avaliacao
                };
            })
            .ToList();

            RelatoriosCollection.ItemsSource = relatorios;
        }
    }
}