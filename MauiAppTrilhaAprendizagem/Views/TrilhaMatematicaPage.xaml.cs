using MauiAppTrilhaAprendizagem.Models;
using MauiAppTrilhaAprendizagem.Data;
using Microsoft.Maui.Controls;

namespace MauiAppTrilhaAprendizagem.Views
{
    public partial class TrilhaMatematicaPage : ContentPage
    {
        int estagioAtual = 1;
        int exercicioAtual = 0;
        int tentativas = 0;
        int acertos = 0;
        int idTrilhaAtual = 1;
        string nomeTrilhaTexto = "";

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
            ("peixes.png", 10, 4, "QUANTAS PEIXES FALTAM PARA FORMAR O NÚMERO 10?"),
        };

        // Trilha cores
        (string imagem, string respostaCorreta, string pergunta, string[] opcoes)[] perguntasCores =
        {
            ("sol.png", "AMARELO", "QUAL É A COR DO SOL?", new string[] { "AZUL", "AMARELO", "VERMELHO" }),
            ("tomate.png", "VERMELHO", "QUAL É A COR DESTE TOMATE?", new string[] { "VERDE", "ROSA", "VERMELHO" }),
            ("borboleta.png", "AZUL", "QUAL É A COR DA BORBOLETA?", new string[] { "AZUL", "ROXO", "AMARELO" }),
        };

        // Trilha das formas
        (string imagem, string respostaCorreta, string pergunta, string[] opcoes)[] perguntasFormas =
        {
            ("melancia.png", "TRIÂNGULO", "QUAL É A FORMA DA FATIA DE PIZZA?", new string[] { "QUADRADO", "TRIÂNGULO", "CÍRCULO" }),
            ("bola.png", "CÍRCULO", "QUAL É A FORMA DA BOLA?", new string[] { "CÍRCULO", "RETÂNGULO", "TRIÂNGULO" }),
            ("televisao.png", "RETÂNGULO", "QUAL É A FORMA DA TELEVISÃO?", new string[] { "QUADRADO", "RETÂNGULO", "CÍRCULO" }),
        };

        public TrilhaMatematicaPage(AlunoModel alunoModel, int trilhaInicial = 1, int idTrilha = 1)
        {
            InitializeComponent();

            aluno = alunoModel;
            estagioAtual = trilhaInicial;
            idTrilhaAtual = idTrilha;

            nomeTrilhaTexto = idTrilha switch
            {
                1 => "Trilha dos Números",
                2 => "Trilha das Quantidades",
                3 => "Trilha das Cores",
                4 => "Trilha das Formas",
                _ => "Trilha dos Números"
            };

            this.Title = nomeTrilhaTexto;
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

            if (idTrilhaAtual == 3)
            {
                var exercicio = perguntasCores[exercicioAtual];
                ExercicioImage.Source = exercicio.imagem;
                PerguntaLabel.Text = exercicio.pergunta;

                foreach (var opcao in exercicio.opcoes)
                {
                    var botao = new Button { Text = opcao, Margin = new Thickness(5) };
                    botao.Clicked += OnRespostaClicked;
                    BotoesLayout.Children.Add(botao);
                }
            }
            else if (idTrilhaAtual == 4)
            {
                var exercicio = perguntasFormas[exercicioAtual];
                ExercicioImage.Source = exercicio.imagem;
                PerguntaLabel.Text = exercicio.pergunta;

                foreach (var opcao in exercicio.opcoes)
                {
                    var botao = new Button { Text = opcao, Margin = new Thickness(5) };
                    botao.Clicked += OnRespostaClicked;
                    BotoesLayout.Children.Add(botao);
                }
            }
            else
            {
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
        }

        void OnRespostaClicked(object sender, EventArgs e)
        {
            var botao = sender as Button;
            if (botao == null) return;

            tentativas++;
            bool acertou = false;

            if (idTrilhaAtual == 3)
            {
                string resposta = botao.Text;
                string respostaCorreta = perguntasCores[exercicioAtual].respostaCorreta;
                acertou = (resposta == respostaCorreta);
            }
            else if (idTrilhaAtual == 4)
            {
                string resposta = botao.Text;
                string respostaCorreta = perguntasFormas[exercicioAtual].respostaCorreta;
                acertou = (resposta == respostaCorreta);
            }
            else
            {
                int resposta = int.Parse(botao.Text);
                int respostaCorreta = estagioAtual == 1
                    ? exerciciosEstagio1[exercicioAtual].respostaCorreta
                    : exerciciosEstagio2[exercicioAtual].totalDesejado - exerciciosEstagio2[exercicioAtual].quantidadeNaImagem;

                acertou = (resposta == respostaCorreta);
            }

            if (acertou)
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

        async void OnProximoClicked(object sender, EventArgs e)
        {
            exercicioAtual++;

            int limiteTotal = exerciciosEstagio1.Length;
            if (idTrilhaAtual == 3) limiteTotal = perguntasCores.Length;
            if (idTrilhaAtual == 4) limiteTotal = perguntasFormas.Length;

            if (idTrilhaAtual != 3 && idTrilhaAtual != 4 && estagioAtual == 1)
            {
                limiteTotal = exerciciosEstagio1.Length;
            }
            else if (idTrilhaAtual != 3 && idTrilhaAtual != 4 && estagioAtual == 2)
            {
                limiteTotal = exerciciosEstagio2.Length;
            }

            if (exercicioAtual < limiteTotal)
            {
                CarregarExercicio();
            }
            else
            {
                if (idTrilhaAtual != 3 && idTrilhaAtual != 4 && estagioAtual == 1)
                {
                    estagioAtual = 2;
                    exercicioAtual = 0;
                    CarregarExercicio();
                }
                else
                {
                    int pontosGanhos = acertos * 10;
                    await SalvarProgressoNoBancoAsync(nomeTrilhaTexto, pontosGanhos, acertos, tentativas);

                    PerguntaLabel.Text = $"🎉 PARABÉNS!\n\nVocê concluiu com sucesso a {nomeTrilhaTexto}!\n\n⭐ Total de Acertos: {acertos}\n🔄 Total de Tentativas: {tentativas}\n🏆 Pontuação Total: {pontosGanhos} pontos";

                    ExercicioImage.Source = null;
                    FeedbackLabel.Text = "";
                    ProximoButton.IsVisible = false;
                    BotoesLayout.Children.Clear();

                    aluno.TotalAcertos += acertos;
                    aluno.TotalTentativas += tentativas;
                    aluno.PontuacaoTotal += pontosGanhos;
                    OutraTrilhaButton.IsVisible = true;
                }
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
        private async Task SalvarProgressoNoBancoAsync(string nomeTrilha, int pontos, int totalAcertos, int totalTentativas)
        {
            try
            {
                int idUsuario = Preferences.Default.Get("IdUsuarioLogado", 0);
                if (idUsuario != 0)
                {
                    var db = new MauiAppTrilhaAprendizagem.Data.DatabaseContext();
                    await db.AtualizarProgressoAlunoAsync(idUsuario, pontos, totalAcertos, totalTentativas, nomeTrilha, true);
                    aluno.PontuacaoTotal += pontos;
                    aluno.TotalAcertos += totalAcertos;
                    aluno.TotalTentativas += totalTentativas;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao salvar no banco: {ex.Message}");
            }
        }
    }
}
