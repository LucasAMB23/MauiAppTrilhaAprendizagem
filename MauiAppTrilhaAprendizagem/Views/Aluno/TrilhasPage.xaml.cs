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

        // TRILHA JÁ FUNCIONAL
        private async void OnTrilhaNumerosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MauiAppTrilhaAprendizagem.Views.TrilhaMatematicaPage());
        }

        // EM DESENVOLVIMENTO
        private async void OnTrilhaQuantidadesClicked(object sender, EventArgs e)
        {
            await DisplayAlert(
                "Trilha das Quantidades",
                "Esta trilha está em desenvolvimento.",
                "OK");
        }

        private async void OnTrilhaCoresFormasClicked(object sender, EventArgs e)
        {
            await DisplayAlert(
                "Trilha das Cores e Formas",
                "Esta trilha está em desenvolvimento.",
                "OK");
        }

        private async void OnTrilhaDesafiosClicked(object sender, EventArgs e)
        {
            await DisplayAlert(
                "Trilha dos Desafios",
                "Esta trilha está em desenvolvimento.",
                "OK");
        }
    }
}
