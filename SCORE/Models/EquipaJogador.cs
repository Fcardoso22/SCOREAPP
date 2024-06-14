using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Equipa_Jogador")]
public partial class EquipaJogador
{
    [Key]
    [Column("Id_Equipa_Jogador")]
    public int IdEquipaJogador { get; set; }

    [Column("Id_Equipa")]
    public int IdEquipa { get; set; }

    [Column("Id_Jogador")]
    public int IdJogador { get; set; }

    [ForeignKey("IdEquipa")]
    [InverseProperty("EquipaJogadors")]
    public virtual Equipa IdEquipaNavigation { get; set; } = null!;

    [ForeignKey("IdJogador")]
    [InverseProperty("EquipaJogadors")]
    public virtual Jogador IdJogadorNavigation { get; set; } = null!;
}
