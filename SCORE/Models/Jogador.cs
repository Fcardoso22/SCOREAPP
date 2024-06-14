using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Jogador")]
public partial class Jogador
{
    [Key]
    [Column("Id_Jogador")]
    public int IdJogador { get; set; }

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    public int Rating { get; set; }

    [InverseProperty("IdJogadorNavigation")]
    public virtual ICollection<EquipaJogador> EquipaJogadors { get; } = new List<EquipaJogador>();
}
