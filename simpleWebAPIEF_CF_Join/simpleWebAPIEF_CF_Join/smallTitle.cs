namespace simpleWebAPIEF_CF_Join
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("titles")]
    public partial class smallTitle
    {
        [Key]
        [StringLength(6)]
        public string title_id { get; set; }

        [Column("title")]
        [Required]
        [StringLength(80)]
        public string title1 { get; set; }
        public int? ytd_sales { get; set; }
    }

}