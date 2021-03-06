// <auto-generated />
using System;
using CastApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CastApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("CastApi.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            Descricao = "Primeira Categoria"
                        },
                        new
                        {
                            CategoriaId = 2,
                            Descricao = "Segunda Categoria"
                        },
                        new
                        {
                            CategoriaId = 3,
                            Descricao = "Terceira Categoria"
                        });
                });

            modelBuilder.Entity("CastApi.Models.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataTermino")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QtdAlunos")
                        .HasColumnType("int");

                    b.HasKey("CursoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("CastApi.Models.Curso", b =>
                {
                    b.HasOne("CastApi.Models.Categoria", "Categoria")
                        .WithMany("Cursos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("CastApi.Models.Categoria", b =>
                {
                    b.Navigation("Cursos");
                });
#pragma warning restore 612, 618
        }
    }
}
