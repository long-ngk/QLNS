namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProjectDetail
    {
        [Key]
        [StringLength(50)]
        public string ProjectID { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        public string Note { get; set; }

        public virtual User User { get; set; }

        public virtual Project Project { get; set; }
    }
}
