using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Campeonato_Jogo")]
public partial class CampeonatoJogo
{
    [Key]
    [Column("Id_Campeonato_Jogo")]
    public int IdCampeonatoJogo { get; set; }

    [Column("Id_Campeonato")]
    public int IdCampeonato { get; set; }

    [Column("Id_Jogo")]
    public int IdJogo { get; set; }

    [ForeignKey("IdCampeonato")]
    [InverseProperty("CampeonatoJogos")]
    public virtual Campeonato IdCampeonatoNavigation { get; set; } = null!;

    [ForeignKey("IdJogo")]
    [InverseProperty("CampeonatoJogos")]
    public virtual Jogo IdJogoNavigation { get; set; } = null!;
}
