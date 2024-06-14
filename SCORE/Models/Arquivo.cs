namespace SCORE.Models
{
    public class Arquivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Nota { get; set; }
        public long Tamanho { get; set; }
        // Referência ao modelo Aluno
        public Aluno Aluno { get; set; }

        // Propriedade que herda o NMecanografico do modelo Aluno
        //public string NMecanograficoAluno => Aluno?.NmecanograficoAluno.ToString();
    }
}



