using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Jogo")]
public partial class Jogo
{
    [Key]
    [Column("Id_Jogo")]
    public int IdJogo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataJogo { get; set; }

    [InverseProperty("IdJogoNavigation")]
    public virtual ICollection<CampeonatoJogo> CampeonatoJogos { get; } = new List<CampeonatoJogo>();
}
