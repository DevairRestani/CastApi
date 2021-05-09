using CastApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CastApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Curso> Cursos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Database.ExecuteSqlRawAsync("CREATE DATABASE IF NOT EXISTS 'cursosDb'");

            Categoria[] categorias = new Categoria[3]
            {
                new Categoria {Descricao = "Primeira Categoria", CategoriaId = 1},
                new Categoria {Descricao = "Segunda Categoria", CategoriaId = 2},
                new Categoria {Descricao = "Terceira Categoria", CategoriaId = 3}
            };

            modelBuilder.Entity<Categoria>().HasData(categorias);
        }
    }
}