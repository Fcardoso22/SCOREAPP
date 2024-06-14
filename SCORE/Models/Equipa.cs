using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Equipa")]
public partial class Equipa
{
    [Key]
    [Column("Id_Equipa")]
    public int IdEquipa { get; set; }

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    [Column("Overall_Rating")]
    public int OverallRating { get; set; }

    [InverseProperty("IdEquipaNavigation")]
    public virtual ICollection<AlunoEquipa> AlunoEquipas { get; } = new List<AlunoEquipa>();

    [InverseProperty("IdEquipaNavigation")]
    public virtual ICollection<CampeonatoEquipa> CampeonatoEquipas { get; } = new List<CampeonatoEquipa>();

    [InverseProperty("IdEquipaNavigation")]
    public virtual ICollection<EquipaJogador> EquipaJogadors { get; } = new List<EquipaJogador>();
}
