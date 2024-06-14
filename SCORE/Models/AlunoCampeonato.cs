using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Aluno_Campeonato")]
public partial class AlunoCampeonato
{
    [Key]
    [Column("Id_Aluno_Campeonato")]
    public int IdAlunoCampeonato { get; set; }

    [Column("NMecanograficoAluno")]
    public int NmecanograficoAluno { get; set; }

    [Column("Id_campeonato")]
    public int IdCampeonato { get; set; }

    public int Creditos { get; set; }

    [Column("Num_Entradas")]
    public int NumEntradas { get; set; }

    [Column("Tempo_Min")]
    public int TempoMin { get; set; }

    [Column("Num_Submissoes")]
    public int NumSubmissoes { get; set; }

    [ForeignKey("IdCampeonato")]
    [InverseProperty("AlunoCampeonatos")]
    public virtual Campeonato IdCampeonatoNavigation { get; set; } = null!;

    [ForeignKey("NmecanograficoAluno")]
    [InverseProperty("AlunoCampeonatos")]
    public virtual Aluno NmecanograficoAlunoNavigation { get; set; } = null!;
}
