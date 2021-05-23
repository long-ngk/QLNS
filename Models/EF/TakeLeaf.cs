namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TakeLeaf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TLID { get; set; }

        public DateTime? Date { get; set; }

        public int? ShiftID { get; set; }

        public int? DepartmentID { get; set; }

        public virtual Shift Shift { get; set; }

        public virtual TakeLeaveDetail TakeLeaveDetail { get; set; }
    }
}
