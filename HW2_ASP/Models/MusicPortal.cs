namespace HW2_ASP.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MusicPortal : DbContext
    {
        public MusicPortal()
            : base("name=MusicPortal")
        {
        }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Songs)
                .WithOptional(e => e.Genre)
                .HasForeignKey(e => e.id_song_genre);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Status)
                .HasForeignKey(e => e.id_status);
        }
    }
}
