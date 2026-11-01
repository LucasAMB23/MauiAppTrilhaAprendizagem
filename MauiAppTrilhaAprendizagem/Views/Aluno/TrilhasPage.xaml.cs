using MauiAppTrilhaAprendizagem.Models;
using System;
using Microsoft.Maui.Controls;

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

        // 🧮 Botão 1: Trilha dos Números (Envia o ID 1)
        private async void OnTrilhaNumerosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new MauiAppTrilhaAprendizagem.Views.TrilhaMatematicaPage(aluno, 1, 1));
        }

        // 🎈 Botão 2: Trilha das Quantidades (Envia o ID 2)
        private async void OnTrilhaQuantidadesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new MauiAppTrilhaAprendizagem.Views.TrilhaMatematicaPage(aluno, 2, 2));
        }

        // 🎨 Botão 3: Trilha das Cores (Envia o ID 3)
        private async void OnTrilhaCoresClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new MauiAppTrilhaAprendizagem.Views.TrilhaMatematicaPage(aluno, 1, 3));
        }

        // 📐 Botão 4: Trilha das Formas (Envia o ID 4)
        private async void OnTrilhaFormasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new MauiAppTrilhaAprendizagem.Views.TrilhaMatematicaPage(aluno, 1, 4));
        }
    }
}
