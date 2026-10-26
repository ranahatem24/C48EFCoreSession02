
using C48EFCoreSession02.Configurations;
using C48EFCoreSession02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48EFCoreSession02.DbContexts
{
    internal class CompanyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;DataBase=CompanyDbG01;Trusted_Connection=true;TrustServerCertificate=true");
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Employee With Fluent APIS
            //modelBuilder.Entity<Employee>().ToTable("EmployeesTable");
            //modelBuilder.Entity<Employee>().HasKey(E => E.EmpId);
            //modelBuilder.Entity<Employee>().Property(E => E.EmpId).UseIdentityColumn(10, 10);
            //modelBuilder.Entity<Employee>().Property(E => E.EmpName)
            //    .HasColumnName("EmployeeName")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(50);

            //modelBuilder.Entity<Employee>().Property(E => E.Salary).HasPrecision(10, 2);
            //modelBuilder.Entity<Employee>().ToTable(T => T.HasCheckConstraint("Check_Employee_Age_Range", "[Age] Between 22 And 40"));
            //modelBuilder.Entity<Employee>().Property(E => E.Email).IsRequired();
            //modelBuilder.Entity<Employee>().ToTable(T => T.HasCheckConstraint("Check_Employee_Email", "[Email] like %@%.%"));
            //modelBuilder.Entity<Employee>().Ignore(E => E.UserName);
            //modelBuilder.Entity<Employee>().Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()");//Shadow Property

            #endregion
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfigurations());
            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
            modelBuilder.ApplyConfiguration<EmployeeProject>(new EmployeeProjectConfigurations());
        }
    }
}
