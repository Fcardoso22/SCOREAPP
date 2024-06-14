using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Docente")]
public partial class Docente
{
    [Key]
    [Column("NMecanograficoDocente")]
    public int NmecanograficoDocente { get; set; }

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    [InverseProperty("NmecanograficoDocenteNavigation")]
    public virtual ICollection<DocenteUc> DocenteUcs { get; } = new List<DocenteUc>();
}
