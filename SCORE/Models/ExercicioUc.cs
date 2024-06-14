using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Exercicio_UC")]
public partial class ExercicioUc
{
    [Key]
    [Column("Id_Exercicio_UC")]
    public int IdExercicioUc { get; set; }

    [Column("Id_Exercicio")]
    public int IdExercicio { get; set; }

    [Column("Id_UC")]
    public int IdUc { get; set; }

    [ForeignKey("IdExercicio")]
    [InverseProperty("ExercicioUcs")]
    public virtual Exercicio IdExercicioNavigation { get; set; } = null!;

    [ForeignKey("IdUc")]
    [InverseProperty("ExercicioUcs")]
    public virtual Uc IdUcNavigation { get; set; } = null!;
}
