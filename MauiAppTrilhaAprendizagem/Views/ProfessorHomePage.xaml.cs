namespace MauiAppTrilhaAprendizagem.Views
{
    public partial class ProfessorHomePage : ContentPage
    {
        public ProfessorHomePage()
        {
            InitializeComponent();
        }

        private async void OnAcompanharAlunosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new AcompanharAlunosPage());
        }

        private async void OnRelatoriosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new RelatoriosPage());
        }
        private async void OnGerenciarAtividadesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new GerenciarAtividadesPage());
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Volta para a tela de Login
            await Navigation.PopToRootAsync();
        }
    }
}
