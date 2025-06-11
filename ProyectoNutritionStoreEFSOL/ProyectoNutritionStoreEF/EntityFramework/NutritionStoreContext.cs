using Microsoft.EntityFrameworkCore;
using ProyectoNutritionStoreEF.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNutritionStoreEF.EntityFramework
{
    public class NutritionStoreContext : DbContext
    {
        private const string connectionString = @"Data Source=172.22.228.134; 
                                         Initial Catalog=nutritionstore;
                                         User Id=sa;
			                             Password=MariaIESMM1.;
                                         TrustServerCertificate=True;";
        //Metodo para conectar:
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        //Mapeado de tablas en la base de datos: 
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Suplemento> Suplementos { get; set; }
        public DbSet<GrupoMuscular> GruposMusculares { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuarios_SuplementosFavoritos> Usuarios_SuplementosFavoritos { get; set; }
        public DbSet<Usuarios_EjerciciosFavoritos> Usuarios_EjerciciosFavoritos { get; set; }

        //Esto indica que UsuarioID y EjercicioID/SuplementoID juntos conforman la clave primaria para evitar excepción.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios_EjerciciosFavoritos>()
                .HasKey(u => new { u.UsuarioID, u.EjercicioID });

            modelBuilder.Entity<Usuarios_SuplementosFavoritos>()
                .HasKey(u => new { u.UsuarioID, u.SuplementoID });

            modelBuilder.Entity<Usuario>()
                 .Property(u => u.Username)
                 .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Contraseña)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Foto)
                .IsRequired(false);



            /*modelBuilder.Entity<Usuario>()
                .Property(u => u.FechaNacimiento)
                .IsRequired(true);*/

            modelBuilder.Entity<Usuario>()
                .Property(e => e.FechaRegistro)
                .HasColumnName("FechaRegistro");

            modelBuilder.Entity<Ejercicio>()
                .Property(e => e.FechaAnadido)
                .HasColumnName("FechaAñadido");

            modelBuilder.Entity<Ejercicio>()
                .Property(u => u.Foto)
                .IsRequired(false);

            modelBuilder.Entity<Suplemento>()
                .Property(u => u.Foto)
                .IsRequired(false);

            modelBuilder.Entity<Suplemento>()
                .Property(e => e.FechaAnadido)
                .HasColumnName("FechaAñadido");

            /*modelBuilder.Entity<Suplemento>()
                .Property(s => s.Precio)
                .HasConversion<double>();*/

           /* modelBuilder.Entity<Ejercicio>()
                .HasMany(e => e.)
                .WithOne()
                .HasForeignKey(u => u.EjercicioID)
                .OnDelete(DeleteBehavior.Cascade);*/


        }


    }

}