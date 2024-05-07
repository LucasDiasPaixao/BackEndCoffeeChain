using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class CoffeeChainContext : DbContext
{
    public CoffeeChainContext()
    {
    }

    public CoffeeChainContext(DbContextOptions<CoffeeChainContext> options)
        : base(options)
    {
    }

    public  DbSet<Armazem> Armazens { get; set; }

    public  DbSet<Empresa> Empresas { get; set; }

    public  DbSet<Entrada> Entradas { get; set; }

    public  DbSet<Produtores> Produtores { get; set; }

    public  DbSet<Propriedade> Propriedades { get; set; }

    public  DbSet<Saida> Saidas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Lucas;database=CoffeeChain;Trusted_Connection=true;Trustservercertificate=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Armazem>(entity =>
        {
            entity.HasKey(e => e.ArmazemId).HasName("PK_Armazens_1");

            entity.Property(e => e.CidadeArmazem)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailArmazem)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EnderecoArmazem)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TelefoneArmazem)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UfArmazem)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Armazem)
                .HasForeignKey(d => d.EmpresaId);
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.Property(e => e.CepEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CidadeEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CnpjEmpresa)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CNPJEmpresa");
            entity.Property(e => e.EmailEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EnderecoEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NomeFantasia)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PaisEmpresa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TelefoneEmpresa)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UfEmpresa)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.Property(e => e.CodigoLote)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CustoEntrada).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EmbalagemArmazenado)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocalArmazenado)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NfeEntrada)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PrecoLote).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.QtdSacas).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Safra)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TipoCafe)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Armazem).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.ArmazemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entradas_Armazens");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entradas_Empresas");

            entity.HasOne(d => d.Produtor).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.ProdutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entradas_Produtores");

            entity.HasOne(d => d.Propriedade).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.PropriedadeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entradas_Propriedades");
        });

        modelBuilder.Entity<Produtores>(entity =>
        {
            entity.HasKey(e => e.ProdutorId);

            entity.Property(e => e.CepProdutor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CidadeProdutor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CpfProdutor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmailProdutor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EnderecoProdutor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NomeProdutor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RgProdutor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TelefoneProdutor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UfProdutor)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Propriedade>(entity =>
        {

            entity.HasKey(e => e.PropriedadeId);

            entity.Property(e => e.CepPropriedade)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CidadePropriedade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CnpjFazenda)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CNPJFazenda");
            entity.Property(e => e.EmailPropriedade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EnderecoPropriedade)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.InscEstadual)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NomeFazenda)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TelefonePropriedade)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UfPropriedade)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.HasOne(d => d.Produtor).WithMany(p => p.Propriedades)
                .HasForeignKey(d => d.ProdutorId)
                .HasConstraintName("FK_Propriedades_Produtores");
        });

        modelBuilder.Entity<Saida>(entity =>
        {
            entity.Property(e => e.CustoSaida).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EmbalagemSaida)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NfeSaida)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecoSaida).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.QtdSacas).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.DestinoEmpresa).WithMany(p => p.Saida)
                .HasForeignKey(d => d.DestinoEmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Saidas_Empresas");

            entity.HasOne(d => d.DestinoProdutor).WithMany(p => p.Saida)
                .HasForeignKey(d => d.DestinoProdutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Saidas_Produtores");

            entity.HasOne(d => d.DestinoPropriedade).WithMany(p => p.Saida)
                .HasForeignKey(d => d.DestinoPropriedadeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Saidas_Propriedades");

            entity.HasOne(d => d.Entrada).WithMany(p => p.Saida)
                .HasForeignKey(d => d.EntradaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Saidas_Entradas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
