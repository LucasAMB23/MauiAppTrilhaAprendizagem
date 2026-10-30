using MauiAppTrilhaAprendizagem.Models;

namespace MauiAppTrilhaAprendizagem.Views.Aluno
{
    public partial class ExerciciosPage : ContentPage
    {
        private AlunoModel aluno;

        public ExerciciosPage(AlunoModel alunoModel)
        {
            InitializeComponent();
            aluno = alunoModel;
        }

        private async void OnFinalizarExercicioClicked(object sender, EventArgs e)
        {
            var exercicio = new ExercicioModel
            {
                Nome = "Contar bolas",
                Pontuacao = 10,
                Tentativas = 1,
                Concluido = true
            };

            aluno.Exercicios.Add(exercicio);
            aluno.PontuacaoTotal += exercicio.Pontuacao;

            await DisplayAlert("Parabéns!", $"Você ganhou {exercicio.Pontuacao} pontos!", "OK");
            await Navigation.PopAsync();
        
        }
    }
}
