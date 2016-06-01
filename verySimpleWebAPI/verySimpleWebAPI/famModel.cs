namespace verySimpleWebAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class famModel : DbContext
    {
        public famModel()
            : base("name=famModel")
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
