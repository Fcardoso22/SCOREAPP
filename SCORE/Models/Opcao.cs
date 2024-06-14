using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCORE.Models
{
    public class Opcao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Texto { get; set; }

        public bool Correta { get; set; }

        [ForeignKey("Exercicio")]
        public int ExercicioId { get; set; }

        public virtual Exercicio Exercicio { get; set; }
    }
}
