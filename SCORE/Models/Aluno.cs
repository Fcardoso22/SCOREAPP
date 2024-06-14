using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Aluno")]
public partial class Aluno
{
    [Key]
    [Column("NMecanograficoAluno")]
    public int NmecanograficoAluno { get; set; }

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    [InverseProperty("NmecanograficoAlunoNavigation")]
    public virtual ICollection<AlunoCampeonato> AlunoCampeonatos { get; } = new List<AlunoCampeonato>();

    [InverseProperty("NmecanograficoAlunoNavigation")]
    public virtual ICollection<AlunoEquipa> AlunoEquipas { get; } = new List<AlunoEquipa>();

    [InverseProperty("NmecanograficoAlunoNavigation")]
    public virtual ICollection<TurmaAluno> TurmaAlunos { get; } = new List<TurmaAluno>();
    public string Role { get; internal set; }
}
