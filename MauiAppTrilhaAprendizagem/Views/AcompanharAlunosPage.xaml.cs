using MauiAppTrilhaAprendizagem.Data;

namespace MauiAppTrilhaAprendizagem.Views
{
    public partial class AcompanharAlunosPage : ContentPage
    {
        private readonly DatabaseContext _db;

        public AcompanharAlunosPage()
        {
            InitializeComponent();

            _db = new DatabaseContext();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var usuarios = await _db.GetUsuariosAsync();

            AlunosCollection.ItemsSource =
                usuarios.Where(u => u.Perfil == "Aluno").ToList();
        }
    }
}