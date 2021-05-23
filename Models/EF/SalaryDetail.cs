namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SalaryDetail
    {
        [Key]
        [Column(Order = 0)]
        public long SalaryID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string UserID { get; set; }

        public decimal? TongLuong { get; set; }

        public int Status { get; set; }

        public virtual Salary Salary { get; set; }

        public virtual User User { get; set; }
    }
}
