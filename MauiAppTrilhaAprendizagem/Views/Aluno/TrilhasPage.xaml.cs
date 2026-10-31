using MauiAppTrilhaAprendizagem.Models;

namespace MauiAppTrilhaAprendizagem.Views.Aluno
{
    public partial class TrilhasPage : ContentPage
    {
        private AlunoModel aluno;

        public TrilhasPage(AlunoModel alunoModel)
        {
            InitializeComponent();
            aluno = alunoModel;
        }

        // 🧮 Trilha dos Números
        private async void OnTrilhaNumerosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new MauiAppTrilhaAprendizagem.Views.TrilhaMatematicaPage(aluno, 1));
        }

        // 🎈 Trilha das Quantidades
        private async void OnTrilhaQuantidadesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new MauiAppTrilhaAprendizagem.Views.TrilhaMatematicaPage(aluno, 2));
        }

        // 🎨 Trilha das Cores e Formas
        private async void OnTrilhaCoresFormasClicked(object sender, EventArgs e)
        {
            await DisplayAlert(
                "Trilha das Cores e Formas",
                "Esta trilha está em desenvolvimento.",
                "OK");
        }

        // 🧠 Trilha dos Desafios
        private async void OnTrilhaDesafiosClicked(object sender, EventArgs e)
        {
            await DisplayAlert(
                "Trilha dos Desafios",
                "Esta trilha está em desenvolvimento.",
                "OK");
        }
    }
}
