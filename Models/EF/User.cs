namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            ProjectDetails = new HashSet<ProjectDetail>();
            SalaryDetails = new HashSet<SalaryDetail>();
            TakeLeaveDetails = new HashSet<TakeLeaveDetail>();
            TimekeepingDetails = new HashSet<TimekeepingDetail>();
            UserSalaries = new HashSet<UserSalary>();
            Roles = new HashSet<Role>();
        }

        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(50)]
        public string CMND { get; set; }

        public int? DepartmentID { get; set; }

        public int? TitleID { get; set; }

        public int? ShiftID { get; set; }

        [StringLength(50)]
        public string AcademicLevel { get; set; }

        public string ForeignLanguageSkill { get; set; }

        public string Degree { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectDetail> ProjectDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalaryDetail> SalaryDetails { get; set; }

        public virtual Shift Shift { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TakeLeaveDetail> TakeLeaveDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimekeepingDetail> TimekeepingDetails { get; set; }

        public virtual Title Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSalary> UserSalaries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
