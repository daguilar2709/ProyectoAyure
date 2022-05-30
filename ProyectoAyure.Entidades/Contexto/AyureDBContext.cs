using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoAyure.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Data.Contexto
{
    public class AyureDbContext : DbContext
    {
        SqlConnection con;

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Perfiles> Perfiles { get; set; }
        public DbSet<UsuarioAcceso> UsuarioAcceso { get; set; }
        public DbSet<Solicitudes> Solicitudes { get; set; }
        public DbSet<Materiales> Materiales { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        public AyureDbContext(DbContextOptions<AyureDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                con.ConnectionString = "Data Source=LAPTOP-1U4QBTGH;Initial Catalog=AyureBD;Integrated Security=True;";
                builder.UseSqlServer(con.ConnectionString);
            }
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
                .HasOne(a => a.perfiles)
                .WithMany(b => b.usuarios);

            modelBuilder.Entity<Usuarios>().Property(a => a.perfilId).ValueGeneratedNever();

            modelBuilder.Entity<Perfiles>()
                .HasMany(a => a.usuarios)
                .WithOne(b => b.perfiles);

            modelBuilder.Entity<UsuarioAcceso>()
                .HasOne(a => a.usuarios)
                .WithOne(b => b.usuarioAcceso)
                .HasForeignKey<Usuarios>(b => b.usuarioAccesoId);

            //modelBuilder.Entity<Ticket>()
            //    .HasMany<Solicitudes>(a => a.solicitudId)
            //    .WithMany(b => b.);

            modelBuilder.Entity<Usuarios>().Property(a => a.perfilId).ValueGeneratedNever();
        }
    }
}
