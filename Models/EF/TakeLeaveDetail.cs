namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TakeLeaveDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TLID { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        public string Reason { get; set; }

        public virtual User User { get; set; }

        public virtual TakeLeaf TakeLeaf { get; set; }
    }
}
