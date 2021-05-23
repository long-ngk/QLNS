namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserSalary
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CSID { get; set; }

        public int? TimeWorking { get; set; }

        public decimal? PhuCap { get; set; }

        public decimal? LuongCoBan { get; set; }

        public virtual CoefficientSalary CoefficientSalary { get; set; }

        public virtual User User { get; set; }
    }
}
