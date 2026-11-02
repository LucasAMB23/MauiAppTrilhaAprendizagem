namespace MauiAppTrilhaAprendizagem.Views
{
    public partial class DesignerHomePage : ContentPage
    {
        public DesignerHomePage()
        {
            InitializeComponent();
        }

        private async void OnCriarConteudosClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Criar Conteúdos", "Aqui o designer pedagógico poderá criar novos conteúdos.", "OK");
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Volta para a tela de Login
            await Navigation.PopToRootAsync();
        }
    }
}
