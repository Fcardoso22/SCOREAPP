using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Aluno_Equipa")]
public partial class AlunoEquipa
{
    [Key]
    [Column("Id_Aluno_Equipa")]
    public int IdAlunoEquipa { get; set; }

    [Column("NMecanograficoAluno")]
    public int NmecanograficoAluno { get; set; }

    [Column("Id_Equipa")]
    public int IdEquipa { get; set; }

    [Column("Id_Turma")]
    public int IdTurma { get; set; }

    [ForeignKey("IdEquipa")]
    [InverseProperty("AlunoEquipas")]
    public virtual Equipa IdEquipaNavigation { get; set; } = null!;

    [ForeignKey("NmecanograficoAluno")]
    [InverseProperty("AlunoEquipas")]
    public virtual Aluno NmecanograficoAlunoNavigation { get; set; } = null!;
}
