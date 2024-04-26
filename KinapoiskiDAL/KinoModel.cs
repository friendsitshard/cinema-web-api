using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KinapoiskiDAL
{
    public partial class KinoModel : DbContext
    {
        public KinoModel()
            : base("name=KinoModel")
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<MovieActor> MovieActors { get; set; }
        public virtual DbSet<Movy> Movies { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Actor>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Actor>()
                .HasMany(e => e.MovieActors)
                .WithRequired(e => e.Actor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MovieActor>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<Movy>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Movy>()
                .Property(e => e.Genre)
                .IsUnicode(false);

            modelBuilder.Entity<Movy>()
                .Property(e => e.Rating)
                .IsUnicode(false);

            modelBuilder.Entity<Movy>()
                .HasMany(e => e.MovieActors)
                .WithRequired(e => e.Movy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
