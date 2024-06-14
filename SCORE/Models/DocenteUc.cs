using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Docente_UC")]
public partial class DocenteUc
{
    [Key]
    [Column("Id_Docente_UC")]
    public int IdDocenteUc { get; set; }

    [Column("NMecanograficoDocente")]
    public int NmecanograficoDocente { get; set; }

    [Column("id_UC")]
    public int IdUc { get; set; }

    [ForeignKey("IdUc")]
    [InverseProperty("DocenteUcs")]
    public virtual Uc IdUcNavigation { get; set; } = null!;

    [ForeignKey("NmecanograficoDocente")]
    [InverseProperty("DocenteUcs")]
    public virtual Docente NmecanograficoDocenteNavigation { get; set; } = null!;
}
