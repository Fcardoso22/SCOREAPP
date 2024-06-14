using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Campeonato")]
public partial class Campeonato
{
    [Key]
    [Column("Id_Campeonato")]
    public int IdCampeonato { get; set; }

    public bool Terminado { get; set; }

    [Column("Id_Turma")]
    public int IdTurma { get; set; }

    [Column("Id_UC")]
    public int IdUC { get; set; }


    [InverseProperty("IdCampeonatoNavigation")]
    public virtual ICollection<AlunoCampeonato> AlunoCampeonatos { get; } = new List<AlunoCampeonato>();

    [InverseProperty("IdCampeonatoNavigation")]
    public virtual ICollection<CampeonatoEquipa> CampeonatoEquipas { get; } = new List<CampeonatoEquipa>();

    [InverseProperty("IdCampeonatoNavigation")]
    public virtual ICollection<CampeonatoJogo> CampeonatoJogos { get; } = new List<CampeonatoJogo>();

    [ForeignKey("IdTurma")]
    [InverseProperty("Campeonatos")]
    public virtual Turma IdTurmaNavigation { get; set; } = null!;

    [ForeignKey("IdUC")]
    [InverseProperty("Campeonatos")]
    public virtual Uc IdUcNavigation { get; set; } = null!;


}
