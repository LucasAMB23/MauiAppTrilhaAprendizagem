using Microsoft.Maui.Controls;

namespace MauiAppTrilhaAprendizagem.Views
{
    public partial class TrilhaMatematicaPage : ContentPage
    {
        int estagioAtual = 1;
        int exercicioAtual = 0;
        int tentativas = 0;
        int acertos = 0;

        // Estágio 1 (contagem direta)
        (string imagem, int respostaCorreta, string pergunta)[] exerciciosEstagio1 =
        {
            ("bolas.png", 3, "QUANTAS BOLAS TEM NA IMAGEM?"),
            ("carrinhos.png", 8, "QUANTOS CARRINHOS TEM NA IMAGEM?"),
            ("bonecas.png", 3, "QUANTAS BONECAS TEM NA IMAGEM?")
        };

        // Estágio 2 (completar quantidades)
        (string imagem, int totalDesejado, int quantidadeNaImagem, string pergunta)[] exerciciosEstagio2 =
        {
            ("ursinhos.jpg", 5, 2, "QUANTOS URSINHOS FALTAM PARA FORMAR O NÚMERO 5?"),
            ("baloes.jpg", 3, 2, "QUANTOS BALÕES FALTAM PARA FORMAR O NÚMERO 3?"),
            ("flores.jpg", 7, 3, "QUANTAS FLORES FALTAM PARA FORMAR O NÚMERO 7?")
        };

        public TrilhaMatematicaPage()
        {
            InitializeComponent();
            CarregarExercicio();
        }

        void CarregarExercicio()
        {
            ExercicioImage.Source = null;
            PerguntaLabel.Text = "";
            FeedbackLabel.Text = "";
            ProximoButton.IsVisible = false;
            BotoesLayout.Children.Clear();

            if (estagioAtual == 1)
            {
                var exercicio = exerciciosEstagio1[exercicioAtual];
                ExercicioImage.Source = exercicio.imagem;
                PerguntaLabel.Text = exercicio.pergunta;

                int maxOpcoes = Math.Max(exercicio.respostaCorreta + 2, 5);
                if (maxOpcoes > 10) maxOpcoes = 10;

                for (int i = 1; i <= maxOpcoes; i++)
                {
                    var botao = new Button { Text = i.ToString() };
                    botao.Clicked += OnRespostaClicked;
                    BotoesLayout.Children.Add(botao);
                }
            }
            else
            {
                var exercicio = exerciciosEstagio2[exercicioAtual];
                int respostaCorreta = exercicio.totalDesejado - exercicio.quantidadeNaImagem;

                ExercicioImage.Source = exercicio.imagem;
                PerguntaLabel.Text = exercicio.pergunta;

                int maxOpcoes = Math.Max(respostaCorreta + 2, 5);
                if (maxOpcoes > 10) maxOpcoes = 10;

                for (int i = 1; i <= maxOpcoes; i++)
                {
                    var botao = new Button { Text = i.ToString() };
                    botao.Clicked += OnRespostaClicked;
                    BotoesLayout.Children.Add(botao);
                }
            }
        }

        void OnRespostaClicked(object sender, EventArgs e)
        {
            var botao = sender as Button;
            int resposta = int.Parse(botao.Text);
            tentativas++;

            int respostaCorreta = estagioAtual == 1
                ? exerciciosEstagio1[exercicioAtual].respostaCorreta
                : exerciciosEstagio2[exercicioAtual].totalDesejado - exerciciosEstagio2[exercicioAtual].quantidadeNaImagem;

            if (resposta == respostaCorreta)
            {
                acertos++;

                FeedbackLabel.Text = "MUITO BEM!";
                FeedbackLabel.TextColor = Colors.Green;
                ProximoButton.IsVisible = true;
            }

            else
            {
                FeedbackLabel.Text = "VAMOS TENTAR DE NOVO!";
                FeedbackLabel.TextColor = Colors.Red;
            }
        }

        void OnProximoClicked(object sender, EventArgs e)
        {
            exercicioAtual++;

            if (estagioAtual == 1 && exercicioAtual < exerciciosEstagio1.Length)
            {
                CarregarExercicio();
            }
            else if (estagioAtual == 1 && exercicioAtual >= exerciciosEstagio1.Length)
            {
                estagioAtual = 2;
                exercicioAtual = 0;
                PerguntaLabel.Text = "Parabéns! Você concluiu o Estágio 1! Agora vamos para o Estágio 2.";
                ExercicioImage.Source = null;
                FeedbackLabel.Text = "";
                ProximoButton.IsVisible = true;
            }
            else if (estagioAtual == 2 && exercicioAtual < exerciciosEstagio2.Length)
            {
                CarregarExercicio();
            }
            else
            {
                PerguntaLabel.Text = "Parabéns! Você concluiu todos os estágios!";
                ExercicioImage.Source = null;
                FeedbackLabel.Text = "";
                ProximoButton.IsVisible = false;
                BotoesLayout.Children.Clear();
            }
        }
    }
}

