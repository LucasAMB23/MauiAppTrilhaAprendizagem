using MauiAppTrilhaAprendizagem.Models;
using MauiAppTrilhaAprendizagem.Views.Aluno;

namespace MauiAppTrilhaAprendizagem.Views
{
    public partial class AlunoHomePage : ContentPage
    {
        private AlunoModel aluno;

        // Construtor que recebe o AlunoModel
        public AlunoHomePage(AlunoModel alunoModel)
        {
            InitializeComponent();
            aluno = alunoModel;
        }

        private async void OnTrilhasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrilhasPage(aluno));
        }

        private async void OnProgressoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProgressoPage(aluno));
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
