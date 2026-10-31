using MauiAppTrilhaAprendizagem.Models;
using Microsoft.Maui.Controls;

namespace MauiAppTrilhaAprendizagem.Views

{ 
    public partial class TrilhaMatematicaPage : ContentPage
    {
        int estagioAtual = 1;
        int exercicioAtual = 0;
        int tentativas = 0;
        int acertos = 0;

        private AlunoModel aluno;

        // Estágio 1 (contagem direta)
        (string imagem, int respostaCorreta, string pergunta)[] exerciciosEstagio1 =
        {
            ("bolas.png", 3, "QUANTAS BOLAS TEM NA IMAGEM?"),
            ("carrinhos.png", 8, "QUANTOS CARRINHOS TEM NA IMAGEM?"),
            ("bonecas.png", 4, "QUANTAS BONECAS TEM NA IMAGEM?"),
            ("estrelas.png", 9, "QUANTAS ESTRELAS TEM NA IMAGEM?"),
            ("ursinhos.png", 5, "QUANTAS URSINHOS TEM NA IMAGEM?"),
        };

        // Estágio 2 (completar quantidades)
        (string imagem, int totalDesejado, int quantidadeNaImagem, string pergunta)[] exerciciosEstagio2 =
        {
            ("baloes.jpg", 3, 2, "QUANTOS BALÕES FALTAM PARA FORMAR O NÚMERO 3?"),
            ("flores.jpg", 7, 3, "QUANTAS FLORES FALTAM PARA FORMAR O NÚMERO 7?"),
            ("patinhos.png", 4, 3, "QUANTOS PATINHOS FALTAM PARA FORMAR O NÚMERO 4?"),
            ("macas.png", 8, 6, "QUANTAS MAÇÃS FALTAM PARA FORMAR O NÚMERO 8?"),
            ("peixes.png", 10, 4, "QUANTAS PEIXES FALTAM PARA FORMAR O NÚMERO 10?")
        };

        public TrilhaMatematicaPage(AlunoModel alunoModel, int trilhaInicial = 1)
        {
            InitializeComponent();

            aluno = alunoModel;

            estagioAtual = trilhaInicial;

            CarregarExercicio();
        }

       void CarregarExercicio()
        {
            ExercicioImage.Source = null;
            PerguntaLabel.Text = "";

            FeedbackLabel.Text = "";

            ProximoButton.IsVisible = false;
            ProximoButton.Text = "Próximo";

            OutraTrilhaButton.IsVisible = false;
            
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

                PerguntaLabel.Text =
            $@"🎉 PARABÉNS!

Você concluiu a Trilha dos Números!

⭐ Acertos: {acertos}

🔄 Tentativas: {tentativas}

🏆 Pontuação: {acertos * 10} pontos";

                ExercicioImage.Source = null;
                FeedbackLabel.Text = "";
                ProximoButton.IsVisible = false;

                BotoesLayout.Children.Clear();

                OutraTrilhaButton.IsVisible = true;
            }

            else if (estagioAtual == 2 && exercicioAtual < exerciciosEstagio2.Length)
            {
                CarregarExercicio();
            }
            else
            {
                PerguntaLabel.Text =
               
                    $@"🎉 PARABÉNS!


                    Você concluiu a Trilha das Quantidades!


                    ⭐ Acertos: {acertos}


                    🔄 Tentativas: {tentativas}


                    🏆 Pontuação: {acertos * 10} pontos";
              
                ExercicioImage.Source = null;
                FeedbackLabel.Text = "";
                ProximoButton.IsVisible = false;
                BotoesLayout.Children.Clear();
                aluno.TotalAcertos += acertos;
                aluno.TotalTentativas += tentativas;
                aluno.PontuacaoTotal += acertos * 10;
                OutraTrilhaButton.IsVisible = true;
            }
        }
         async void OnMenuClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        async void OnProgressoClicked(object sender, EventArgs e)
        {
            await DisplayAlert(
                "Meu Progresso",
                $"Acertos: {acertos}\nTentativas: {tentativas}\nPontuação: {acertos * 10}",
                "OK");
        }
        async void OnOutraTrilhaClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

