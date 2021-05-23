namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TimekeepingDetail
    {
        [Key]
        public long TKID { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        public DateTime? Time { get; set; }

        public int? Status { get; set; }

        public virtual User User { get; set; }

        public virtual Timekeeping Timekeeping { get; set; }
    }
}
