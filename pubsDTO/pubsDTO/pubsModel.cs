namespace pubsDTO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class pubsModel : DbContext
    {
        public pubsModel()
            : base("name=pubsModel")
        {
        }

        public virtual DbSet<publisher> publishers { get; set; }
        public virtual DbSet<title> titles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<publisher>()
                .Property(e => e.pub_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.pub_name)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.state)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.title_id)
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.title1)
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.pub_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<title>()
                .Property(e => e.advance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<title>()
                .Property(e => e.notes)
                .IsUnicode(false);
        }
    }
}
