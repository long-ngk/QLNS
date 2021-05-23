namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Salary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Salary()
        {
            SalaryDetails = new HashSet<SalaryDetail>();
        }

        public long SalaryID { get; set; }

        public int? DepartmentID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Start { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalaryDetail> SalaryDetails { get; set; }
    }
}
