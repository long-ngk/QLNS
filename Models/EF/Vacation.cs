namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vacation
    {
        [StringLength(50)]
        public string VacationID { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Start { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End { get; set; }

        public int? NumberDayOff { get; set; }
    }
}
