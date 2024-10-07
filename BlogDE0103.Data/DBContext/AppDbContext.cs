using BlogDE0103.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BlogDE0103.Data.DBContext
{
    public class AppDbContext : DbContext
    {
        // A;adir migraciones en Infrastructure
        //add-migration InitialMigration -p ELIXStreaming.Infrastructure -c AppDbContext -o Migrations -s ELIXStreaming.Infrastructure


        //add-migration InitialMigration -p BlogDE0103.Data -c AppDbContext -o Migrations -s BlogDE0103.Data
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<ActividadEntity> Actividades { get; set; }
        public DbSet<AvisosEntity> Avisos { get; set; }
        public DbSet<AyudaEntity> Ayudas { get; set; }
        public DbSet<ComentarioEntity> Comentarios { get; set; }
        public DbSet<FAQEntity> FAQ { get; set; }
        public DbSet<NoticiaEntity> Noticias { get; set; }
        public DbSet<PublicoObjetivoEntity> PublicObjetivoActividades { get; set; }
        public DbSet<RolEntity> Roles { get; set; }
        public DbSet<TipoActividadEntity> TipoActividad { get; set; }
        public DbSet<TipoNoticiaEntity> TipoNoticias { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relaciones de Actividad con otras tablas. IDUsuario indica que usuario agrego esa actividad
            modelBuilder.Entity<ActividadEntity>()
                .Property(a => a.Presupuesto)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ActividadEntity>()
                .HasOne(c => c.TipoActividad)
                .WithMany()
                .HasForeignKey(c => c.IDTipoActividad);
            modelBuilder.Entity<ActividadEntity>()
                .HasOne(c => c.PublicoObjetivo)
                .WithMany()
                .HasForeignKey(c => c.IDPublicoObjetivo);
            modelBuilder.Entity<ActividadEntity>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.IDUsuario);

            //Relaciones de Aviso con Usuario con otras tablas. Indica que usuario agrego el aviso
            modelBuilder.Entity<AvisosEntity>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.IDUsuario);
            modelBuilder.Entity<AvisosEntity>()
               .HasOne(c => c.PublicoObjetivo)
               .WithMany()
               .HasForeignKey(c => c.IDPublicoObjetivo);

            //Relaciones de Noticia con otras tablas. IDUsuario indica que usuario agrego esa Noticia
            modelBuilder.Entity<NoticiaEntity>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.IDUsuario);
            modelBuilder.Entity<NoticiaEntity>()
                .HasOne(c => c.TipoNoticia)
                .WithMany()
                .HasForeignKey(c => c.IDTipoNoticia);
            modelBuilder.Entity<NoticiaEntity>()
               .HasOne(c => c.PublicoObjetivo)
               .WithMany()
               .HasForeignKey(c => c.IDPublicoObjetivo);

            //IDUsuario indica que rol tiene ese Usuario
            modelBuilder.Entity<UsuarioEntity>()
                .HasOne(c => c.Rol)
                .WithMany()
                .HasForeignKey(c => c.IDRol);





            modelBuilder.Entity<RolEntity>()
                .HasData(
            new RolEntity
            {
                ID = 1,
                Nombre = "SuperAdmin",
                Descripcion = "SuperAdministrador del sistema, tiene acceso a todas las areas del sistema",
                Eliminado = false,
            },
            new RolEntity
            {
                ID = 2,
                Nombre = "AdminLevel1",
                Descripcion = "Tiene acceso a ciertas areas del sistema, como agregar las actividades, las noticias, los avisos. Pueden agregar y actualizar ciertas informaciones",
                Eliminado = false,
            },
            new RolEntity
            {
                ID = 3,
                Nombre = "AdminLevel2",
                Descripcion = "Tiene acceso a ciertas areas del sistema, como ver las actividades internas, las noticias internas, los avisos internos. No pueden agregar ni actualizar informaciones",
                Eliminado = false,
            }

            );
        }



     }
}







      