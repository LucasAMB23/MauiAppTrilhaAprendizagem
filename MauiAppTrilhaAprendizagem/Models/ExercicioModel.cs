namespace MauiAppTrilhaAprendizagem.Models
{
    public class ExercicioModel
    {
        public string Nome { get; set; }          // Nome do exercício (ex: "Contar bolas")
        public int Pontuacao { get; set; }        // Pontos ganhos
        public int Tentativas { get; set; }       // Quantas vezes tentou
        public bool Concluido { get; set; }       // Se o exercício foi concluído

        public string AtividadeEspecifica { get; set; } = string.Empty; // Atribuir atividade ao aluno
    }
}
