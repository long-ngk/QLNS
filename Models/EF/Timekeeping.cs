namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Timekeeping
    {
        [Key]
        public long TKID { get; set; }

        public int? ShiftID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int? DepartmentID { get; set; }

        public bool? Status { get; set; }

        public virtual Shift Shift { get; set; }

        public virtual TimekeepingDetail TimekeepingDetail { get; set; }
    }
}
