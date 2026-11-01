namespace MauiAppTrilhaAprendizagem.Models
{
    public class AlunoModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int PontuacaoTotal { get; set; }
        public int TotalAcertos { get; set; }
        public int TotalTentativas { get; set; }
        public List<ExercicioModel> Exercicios { get; set; } = new List<ExercicioModel>();
        public bool TrilhaNumerosConcluida { get; set; }
        public bool TrilhaQuantidadesConcluida { get; set; }
        public bool TrilhaCoresFormasConcluida { get; set; }
    }
}
