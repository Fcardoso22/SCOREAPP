using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SCORE.Models;

namespace SCORE.Data;

public partial class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext()
    {
    }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<FileViewModel> Files { get; set; }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<AlunoCampeonato> AlunoCampeonatos { get; set; }

    public virtual DbSet<AlunoEquipa> AlunoEquipas { get; set; }

    public virtual DbSet<Campeonato> Campeonatos { get; set; }

    public virtual DbSet<CampeonatoEquipa> CampeonatoEquipas { get; set; }

    public virtual DbSet<CampeonatoJogo> CampeonatoJogos { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<DocenteUc> DocenteUcs { get; set; }

    public virtual DbSet<Equipa> Equipas { get; set; }

    public virtual DbSet<EquipaJogador> EquipaJogadors { get; set; }

    public virtual DbSet<Exercicio> Exercicios { get; set; }

    public virtual DbSet<ExercicioUc> ExercicioUcs { get; set; }

    public virtual DbSet<Jogador> Jogadors { get; set; }

    public virtual DbSet<Jogo> Jogos { get; set; }

    public virtual DbSet<Opcao> Opcoes { get; set; }

    public virtual DbSet<Turma> Turmas { get; set; }

    public virtual DbSet<TurmaAluno> TurmaAlunos { get; set; }

    public virtual DbSet<TurmaUc> TurmaUcs { get; set; }

    public virtual DbSet<Uc> Ucs { get; set; }

    public object Arquivos { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.NmecanograficoAluno).HasName("PK__Aluno__7C8A234AEFB222B4");

            entity.Property(e => e.NmecanograficoAluno).ValueGeneratedNever();
        });

        modelBuilder.Entity<AlunoCampeonato>(entity =>
        {
            entity.HasKey(e => e.IdAlunoCampeonato).HasName("PK__Aluno_Ca__83E4D97D2B0DD820");

            entity.HasOne(d => d.IdCampeonatoNavigation).WithMany(p => p.AlunoCampeonatos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Aluno_Cam__Id_ca__46E78A0C");

            entity.HasOne(d => d.NmecanograficoAlunoNavigation).WithMany(p => p.AlunoCampeonatos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Aluno_Cam__NMeca__45F365D3");
        });

        modelBuilder.Entity<AlunoEquipa>(entity =>
        {
            entity.HasKey(e => e.IdAlunoEquipa).HasName("PK__Aluno_Eq__9B02E1C300D9DD40");

            entity.HasOne(d => d.IdEquipaNavigation).WithMany(p => p.AlunoEquipas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Aluno_Equ__Id_Eq__4E88ABD4");

            entity.HasOne(d => d.NmecanograficoAlunoNavigation).WithMany(p => p.AlunoEquipas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Aluno_Equ__NMeca__4D94879B");
        });

        modelBuilder.Entity<Campeonato>(entity =>
        {
            entity.HasKey(e => e.IdCampeonato).HasName("PK__Campeona__A8849C34EDC06937");

            entity.Property(e => e.IdCampeonato).ValueGeneratedNever();

            entity.HasOne(d => d.IdTurmaNavigation).WithMany(p => p.Campeonatos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Campeonat__Id_Tu__33D4B598");
        });

        modelBuilder.Entity<CampeonatoEquipa>(entity =>
        {
            entity.HasKey(e => e.IdCampeonatoEquipa).HasName("PK__Campeona__20443250C98E5302");

            entity.HasOne(d => d.IdCampeonatoNavigation).WithMany(p => p.CampeonatoEquipas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Campeonat__Id_Ca__3B75D760");

            entity.HasOne(d => d.IdEquipaNavigation).WithMany(p => p.CampeonatoEquipas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Campeonat__Id_Eq__3A81B327");
        });

        modelBuilder.Entity<CampeonatoJogo>(entity =>
        {
            entity.HasKey(e => e.IdCampeonatoJogo).HasName("PK__Campeona__870298C0FC284ADB");

            entity.HasOne(d => d.IdCampeonatoNavigation).WithMany(p => p.CampeonatoJogos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Campeonat__Id_Ca__5535A963");

            entity.HasOne(d => d.IdJogoNavigation).WithMany(p => p.CampeonatoJogos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Campeonat__Id_Jo__5629CD9C");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.NmecanograficoDocente).HasName("PK__Docente__BAA1BFEF0BE3947F");

            entity.Property(e => e.NmecanograficoDocente).ValueGeneratedNever();
        });

        modelBuilder.Entity<DocenteUc>(entity =>
        {
            entity.HasKey(e => e.IdDocenteUc).HasName("PK__Docente___2E47949A93F1E34E");

            entity.HasOne(d => d.IdUcNavigation).WithMany(p => p.DocenteUcs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Docente_U__id_UC__3F466844");

            entity.HasOne(d => d.NmecanograficoDocenteNavigation).WithMany(p => p.DocenteUcs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Docente_U__NMeca__3E52440B");
        });

        modelBuilder.Entity<Equipa>(entity =>
        {
            entity.HasKey(e => e.IdEquipa).HasName("PK__Equipa__4B9119CE57613823");
        });

        modelBuilder.Entity<EquipaJogador>(entity =>
        {
            entity.HasKey(e => e.IdEquipaJogador).HasName("PK__Equipa_J__65683B32B2C79ABC");

            entity.HasOne(d => d.IdEquipaNavigation).WithMany(p => p.EquipaJogadors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Equipa_Jo__Id_Eq__49C3F6B7");

            entity.HasOne(d => d.IdJogadorNavigation).WithMany(p => p.EquipaJogadors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Equipa_Jo__Id_Jo__4AB81AF0");
        });

        modelBuilder.Entity<Exercicio>(entity =>
        {
            entity.HasKey(e => e.IdExercicio).HasName("PK__Exercici__8BAE3646C5C2B738");
        });

        modelBuilder.Entity<ExercicioUc>(entity =>
        {
            entity.HasKey(e => e.IdExercicioUc).HasName("PK__Exercici__D473139A0A7D01D9");

            entity.HasOne(d => d.IdExercicioNavigation).WithMany(p => p.ExercicioUcs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exercicio__Id_Ex__4222D4EF");

            entity.HasOne(d => d.IdUcNavigation).WithMany(p => p.ExercicioUcs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exercicio__Id_UC__4316F928");
        });

        modelBuilder.Entity<Jogador>(entity =>
        {
            entity.HasKey(e => e.IdJogador).HasName("PK__Jogador__5720AAD9471CC4B6");
        });

        modelBuilder.Entity<Jogo>(entity =>
        {
            entity.HasKey(e => e.IdJogo).HasName("PK__Jogo__FECD839810E75792");
        });

        modelBuilder.Entity<Turma>(entity =>
        {
            entity.HasKey(e => e.IdTurma).HasName("PK__Turma__5CF918CE321987AE");
        });

        modelBuilder.Entity<TurmaAluno>(entity =>
        {
            entity.HasKey(e => e.IdTurmaAluno).HasName("PK__Turma_Al__AAF950D028AD7F30");

            entity.HasOne(d => d.IdTurmaNavigation).WithMany(p => p.TurmaAlunos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Turma_Alu__Id_Tu__5165187F");

            entity.HasOne(d => d.NmecanograficoAlunoNavigation).WithMany(p => p.TurmaAlunos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Turma_Alu__NMeca__52593CB8");
        });

        modelBuilder.Entity<TurmaUc>(entity =>
        {
            entity.HasKey(e => e.IdTurmaUc).HasName("PK__Turma_UC__CA3EC711F7FA34F5");

            entity.HasOne(d => d.IdTurmaNavigation).WithMany(p => p.TurmaUcs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Turma_UC__Id_Tur__36B12243");

            entity.HasOne(d => d.IdUcNavigation).WithMany(p => p.TurmaUcs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Turma_UC__Id_UC__37A5467C");
        });

        modelBuilder.Entity<Uc>(entity =>
        {
            entity.HasKey(e => e.IdUc).HasName("PK__UC__16EC21A836FAADA2");
        });

        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Entity<IdentityUserRole<string>>()
           .HasKey(x => new { x.UserId, x.RoleId });
        modelBuilder.Entity<IdentityUserToken<string>>()
            .HasKey(x => new { x.UserId, x.LoginProvider, x.Name });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    //public DbSet<SCORE.Models.FileViewModel>? FileViewModel { get; set; }
}
