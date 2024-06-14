using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Campeonato_Equipa")]
public partial class CampeonatoEquipa
{
    [Key]
    [Column("Id_Campeonato_Equipa")]
    public int IdCampeonatoEquipa { get; set; }

    [Column("Id_Equipa")]
    public int IdEquipa { get; set; }

    [Column("Id_Campeonato")]
    public int IdCampeonato { get; set; }

    public int Posicao { get; set; }

    public int Pontuacao { get; set; }

    [ForeignKey("IdCampeonato")]
    [InverseProperty("CampeonatoEquipas")]
    public virtual Campeonato IdCampeonatoNavigation { get; set; } = null!;

    [ForeignKey("IdEquipa")]
    [InverseProperty("CampeonatoEquipas")]
    public virtual Equipa IdEquipaNavigation { get; set; } = null!;
}
