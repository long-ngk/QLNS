namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Project
    {
        [StringLength(50)]
        public string ProjectID { get; set; }

        [Required]
        public string ProjectName { get; set; }

        public DateTime? ProjectStart { get; set; }

        public DateTime? ProjectEnd { get; set; }

        public string Location { get; set; }

        public string ProjectAim { get; set; }

        public int? Status { get; set; }

        public int? DepartmentID { get; set; }

        public virtual Department Department { get; set; }

        public virtual ProjectDetail ProjectDetail { get; set; }
    }
}
