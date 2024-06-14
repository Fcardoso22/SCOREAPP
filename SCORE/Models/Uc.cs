using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("UC")]
public partial class Uc
{
    [Key]
    [Column("Id_UC")]
    public int IdUc { get; set; }

    [StringLength(50)]
    public string Nome { get; set; } = null!;


    [InverseProperty("IdUcNavigation")]
    public virtual ICollection<Campeonato> Campeonatos { get; } = new List<Campeonato>();

    [InverseProperty("IdUcNavigation")]
    public virtual ICollection<DocenteUc> DocenteUcs { get; } = new List<DocenteUc>();

    [InverseProperty("IdUcNavigation")]
    public virtual ICollection<ExercicioUc> ExercicioUcs { get; } = new List<ExercicioUc>();

    [InverseProperty("IdUcNavigation")]
    public virtual ICollection<TurmaUc> TurmaUcs { get; } = new List<TurmaUc>();

    

}
