namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RecruitmentStaff")]
    public partial class RecruitmentStaff
    {
        [Key]
        [StringLength(50)]
        public string RSID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public int? Status { get; set; }

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

        public virtual Department Department { get; set; }

        public virtual Title Title { get; set; }
    }
}
