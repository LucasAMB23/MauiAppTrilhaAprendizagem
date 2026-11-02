using MauiAppTrilhaAprendizagem.Views;
using MauiAppTrilhaAprendizagem.Views.Aluno;

namespace MauiAppTrilhaAprendizagem
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registrar rotas para navegação
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(CadastroPage), typeof(CadastroPage));
            Routing.RegisterRoute(nameof(AlunoHomePage), typeof(AlunoHomePage));
            Routing.RegisterRoute(nameof(ProfessorHomePage), typeof(ProfessorHomePage));
            Routing.RegisterRoute(nameof(DesignerHomePage), typeof(DesignerHomePage));
            Routing.RegisterRoute(nameof(TrilhasPage), typeof(TrilhasPage));
            Routing.RegisterRoute(nameof(ExerciciosPage), typeof(ExerciciosPage));
            Routing.RegisterRoute(nameof(GerenciarAtividadesPage), typeof(GerenciarAtividadesPage));
        }
    }
}
