namespace deleeteme
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=salesModel1")
        {
        }

        public virtual DbSet<sale> sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<sale>()
                .Property(e => e.stor_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sale>()
                .Property(e => e.ord_num)
                .IsUnicode(false);

            modelBuilder.Entity<sale>()
                .Property(e => e.payterms)
                .IsUnicode(false);

            modelBuilder.Entity<sale>()
                .Property(e => e.title_id)
                .IsUnicode(false);
        }
    }
}
