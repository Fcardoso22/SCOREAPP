using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Exercicio")]
public partial class Exercicio
{
    [Key]
    [Column("Id_Exercicio")]
    public int IdExercicio { get; set; }

    public string Titulo { get; set; }

    public string Descricao { get; set; }

    public int? Nota { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataEntrega { get; set; }

    public ExercicioTipo Tipo { get; set; }

    public string Pergunta { get; set; }

    public string Resposta { get; set; }

    [InverseProperty("IdExercicioNavigation")]
    public virtual ICollection<ExercicioUc> ExercicioUcs { get; } = new List<ExercicioUc>();

    [InverseProperty("Exercicio")]
    public virtual ICollection<Opcao> Opcoes { get; } = new List<Opcao>();
}
