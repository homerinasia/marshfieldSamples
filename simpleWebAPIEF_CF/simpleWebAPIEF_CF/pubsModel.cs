namespace simpleWebAPIEF_CF
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

        public virtual DbSet<family> families { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<family>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
