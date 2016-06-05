namespace mvc_ef_cf
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class familyModel : DbContext
    {
        public familyModel()
            : base("name=familyModel")
        {
        }

        public virtual DbSet<family> families { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<family>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
