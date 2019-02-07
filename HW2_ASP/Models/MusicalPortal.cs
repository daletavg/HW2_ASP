namespace HW2_ASP.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MusicalPortal : DbContext
    {
        public MusicalPortal()
            : base("name=MusicalPortal")
        {
        }

        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Song> Song { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Song)
                .WithOptional(e => e.Genre)
                .HasForeignKey(e => e.id_song_genre);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.User)
                .WithOptional(e => e.Status)
                .HasForeignKey(e => e.id_status);
        }
    }
}
