﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SegurancaTrabalho.Repository.Context;

namespace Repository.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231201114647_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("Domain.Entities.Entities.Cargo_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("cargo");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Cliente_Cargo_Entity", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "CargoId");

                    b.HasIndex("CargoId");

                    b.ToTable("cliente_cargo");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Cliente_Colaborador_Entity", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "ColaboradorId");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("cliente_colaborador");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Cliente_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEmpresa")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<int>("IdFuncionario")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<int>("IdRamoDeAtividade")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("IdFuncionario");

                    b.HasIndex("IdRamoDeAtividade");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Colaborador_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CEP")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<double>("CPF")
                        .HasMaxLength(11)
                        .HasColumnType("double");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ExclusaoLogica")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<int>("IdEmpresa")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("NumeroEndereco")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<int>("PermissaoId")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<int>("RG")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpresa");

                    b.HasIndex("PermissaoId");

                    b.HasIndex("Senha")
                        .IsUnique();

                    b.ToTable("colaborador");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Empresa_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("empresa");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Funcionario_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("CPF")
                        .HasMaxLength(11)
                        .HasColumnType("double");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("IdCargo")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RG")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCargo");

                    b.ToTable("funcionario");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Permissao_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TipoPermissao")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id");

                    b.ToTable("permissao");
                });

            modelBuilder.Entity("Domain.Entities.Entities.RamoDeAtividade_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("ramo_atividade");
                });

            modelBuilder.Entity("SegurancaTrabalho.BusinessEntities.Entities.Token_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("key")
                        .HasColumnType("longtext");

                    b.Property<string>("tipoPermissao")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Cliente_Cargo_Entity", b =>
                {
                    b.HasOne("Domain.Entities.Entities.Cargo_Entity", "Cargo")
                        .WithMany("ClienteCargos")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Entities.Cliente_Entity", "Cliente")
                        .WithMany("ClienteCargos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Cliente_Colaborador_Entity", b =>
                {
                    b.HasOne("Domain.Entities.Entities.Cliente_Entity", "Cliente")
                        .WithMany("ClienteColaboradores")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Entities.Colaborador_Entity", "Colaborador")
                        .WithMany("ClienteColaboradores")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Cliente_Entity", b =>
                {
                    b.HasOne("Domain.Entities.Entities.Funcionario_Entity", "Funcionario")
                        .WithMany("Clientes")
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Entities.RamoDeAtividade_Entity", "RamoDeAtividade")
                        .WithMany("Cliente")
                        .HasForeignKey("IdRamoDeAtividade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("RamoDeAtividade");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Colaborador_Entity", b =>
                {
                    b.HasOne("Domain.Entities.Entities.Empresa_Entity", "Empresa")
                        .WithMany("Colaboradores")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Entities.Permissao_Entity", "Permissao")
                        .WithMany("Colaboradores")
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Permissao");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Funcionario_Entity", b =>
                {
                    b.HasOne("Domain.Entities.Entities.Cargo_Entity", "Cargo")
                        .WithMany("Funcionarios")
                        .HasForeignKey("IdCargo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Cargo_Entity", b =>
                {
                    b.Navigation("ClienteCargos");

                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Cliente_Entity", b =>
                {
                    b.Navigation("ClienteCargos");

                    b.Navigation("ClienteColaboradores");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Colaborador_Entity", b =>
                {
                    b.Navigation("ClienteColaboradores");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Empresa_Entity", b =>
                {
                    b.Navigation("Colaboradores");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Funcionario_Entity", b =>
                {
                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("Domain.Entities.Entities.Permissao_Entity", b =>
                {
                    b.Navigation("Colaboradores");
                });

            modelBuilder.Entity("Domain.Entities.Entities.RamoDeAtividade_Entity", b =>
                {
                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}