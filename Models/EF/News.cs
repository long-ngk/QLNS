namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [Key]
        [StringLength(50)]
        public string NewID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Alias { get; set; }

        [StringLength(10)]
        public string Header { get; set; }

        public string Content { get; set; }

        [StringLength(100)]
        public string Metakeyword { get; set; }

        public string MetaDescription { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public int? Status { get; set; }

        public int? TagID { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
