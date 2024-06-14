using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SCORE.Models;

[Table("Turma")]
public partial class Turma
{
    [Key]
    [Column("Id_Turma")]
    public int IdTurma { get; set; }

    public int Numero { get; set; }

    public List<Aluno> Alunos { get; set; }

    [InverseProperty("IdTurmaNavigation")]
    public virtual ICollection<Campeonato> Campeonatos { get; } = new List<Campeonato>();

    [InverseProperty("IdTurmaNavigation")]
    public virtual ICollection<TurmaAluno> TurmaAlunos { get; } = new List<TurmaAluno>();

    [InverseProperty("IdTurmaNavigation")]
    public virtual ICollection<TurmaUc> TurmaUcs { get; } = new List<TurmaUc>();

    public static implicit operator SelectList(Turma v)
    {
        throw new NotImplementedException();
    }
}
