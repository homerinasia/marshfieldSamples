namespace efCF_SProc
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ttModel : DbContext
    {
        public ttModel()
            : base("name=ttModel")
        {
        }

        public virtual DbSet<tt> tts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tt>()
                .Property(e => e.fname)
                .IsUnicode(false);

            modelBuilder.Entity<tt>().MapToStoredProcedures
                (
                    p => p.Insert(i => i.HasName("pitt"))
                        .Update(u => u.HasName("putt"))
                        .Delete(d => d.HasName("pdtt"))
                );

        }
    }
}
