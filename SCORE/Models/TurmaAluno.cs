using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Turma_Aluno")]
public partial class TurmaAluno
{
    [Key]
    [Column("Id_Turma_Aluno")]
    public int IdTurmaAluno { get; set; }

    [Column("Id_Turma")]
    public int IdTurma { get; set; }

    [Column("NMecanograficoAluno")]
    public int NmecanograficoAluno { get; set; }

    [ForeignKey("IdTurma")]
    [InverseProperty("TurmaAlunos")]
    public virtual Turma IdTurmaNavigation { get; set; } = null!;

    [ForeignKey("NmecanograficoAluno")]
    [InverseProperty("TurmaAlunos")]
    public virtual Aluno NmecanograficoAlunoNavigation { get; set; } = null!;
}
