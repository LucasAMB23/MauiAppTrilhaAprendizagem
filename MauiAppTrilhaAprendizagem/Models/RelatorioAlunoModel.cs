namespace MauiAppTrilhaAprendizagem.Models
{
    public class RelatorioAlunoModel
    {
        public string Nome { get; set; } = string.Empty;

        public int PontuacaoTotal { get; set; }

        public int TotalAcertos { get; set; }

        public int TotalTentativas { get; set; }

        public int TotalErros { get; set; }

        public string TrilhasConcluidas { get; set; } = string.Empty;

        public double TaxaAcerto { get; set; }

        public string AvaliacaoPedagogica { get; set; } = string.Empty;
    }
}