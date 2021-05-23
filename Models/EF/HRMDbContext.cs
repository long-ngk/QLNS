using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public partial class HRMDbContext : DbContext
    {
        public HRMDbContext()
            : base("name=HRMDbContext")
        {
        }

        public virtual DbSet<CoefficientSalary> CoefficientSalaries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<ProjectDetail> ProjectDetails { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<RecruitmentStaff> RecruitmentStaffs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<SalaryDetail> SalaryDetails { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TakeLeaveDetail> TakeLeaveDetails { get; set; }
        public virtual DbSet<TakeLeaf> TakeLeaves { get; set; }
        public virtual DbSet<TimekeepingDetail> TimekeepingDetails { get; set; }
        public virtual DbSet<Timekeeping> Timekeepings { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSalary> UserSalaries { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoefficientSalary>()
                .HasMany(e => e.UserSalaries)
                .WithRequired(e => e.CoefficientSalary)
                .HasForeignKey(e => e.CSID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<News>()
                .Property(e => e.NewID)
                .IsFixedLength();

            modelBuilder.Entity<News>()
                .Property(e => e.Alias)
                .IsFixedLength();

            modelBuilder.Entity<News>()
                .Property(e => e.Header)
                .IsFixedLength();

            modelBuilder.Entity<News>()
                .Property(e => e.Metakeyword)
                .IsFixedLength();

            modelBuilder.Entity<ProjectDetail>()
                .Property(e => e.ProjectID)
                .IsFixedLength();

            modelBuilder.Entity<ProjectDetail>()
                .HasOptional(e => e.Project)
                .WithRequired(e => e.ProjectDetail);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectID)
                .IsFixedLength();

            modelBuilder.Entity<RecruitmentStaff>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<RecruitmentStaff>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<RecruitmentStaff>()
                .Property(e => e.CMND)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("Admin").MapLeftKey("RoleID").MapRightKey("UserID"));

            modelBuilder.Entity<Salary>()
                .HasMany(e => e.SalaryDetails)
                .WithRequired(e => e.Salary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.TagName)
                .IsFixedLength();

            modelBuilder.Entity<TakeLeaveDetail>()
                .HasOptional(e => e.TakeLeaf)
                .WithRequired(e => e.TakeLeaveDetail);

            modelBuilder.Entity<TimekeepingDetail>()
                .HasOptional(e => e.Timekeeping)
                .WithRequired(e => e.TimekeepingDetail);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.CMND)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.SalaryDetails)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserSalaries)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vacation>()
                .Property(e => e.VacationID)
                .IsFixedLength();
        }
    }
}
