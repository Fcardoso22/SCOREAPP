using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Turma_UC")]
public partial class TurmaUc
{
    [Key]
    [Column("Id_Turma_UC")]
    public int IdTurmaUc { get; set; }

    [Column("Id_Turma")]
    public int IdTurma { get; set; }

    [Column("Id_UC")]
    public int IdUc { get; set; }

    public Turma? Turma { get; set; }

    public Uc? Uc { get; set; }

    [ForeignKey("IdTurma")]
    [InverseProperty("TurmaUcs")]
    public virtual Turma IdTurmaNavigation { get; set; } = null!;

    [ForeignKey("IdUc")]
    [InverseProperty("TurmaUcs")]
    public virtual Uc IdUcNavigation { get; set; } = null!;
}
