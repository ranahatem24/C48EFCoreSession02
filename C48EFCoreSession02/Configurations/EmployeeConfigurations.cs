using C48EFCoreSession02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48EFCoreSession02.Configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("EmployeesTable");
            builder.HasKey(E => E.EmpId);
            builder.Property(E => E.EmpId).UseIdentityColumn(10, 10);
            builder.Property(E => E.EmpName)
                .HasColumnName("EmployeeName")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(E => E.Salary).HasPrecision(10, 2);
            builder.ToTable(T => T.HasCheckConstraint("Check_Employee_Age_Range", "[Age] Between 22 And 40"));
            builder.Property(E => E.Email).IsRequired();
            builder.ToTable(T => T.HasCheckConstraint("Check_Employee_Email", "[Email] like '%@%.%'"));
            builder.Ignore(E => E.UserName);
            builder.Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()");//Shadow Property

            builder.ComplexProperty(E => E.EmployeeAddress);//FECore 8 (1-1 Manadtory)

            #region Work RelationShip
            builder.HasOne(E => E.EmployeeDepartment)
                .WithMany(D => D.Employees)
                .HasForeignKey(E => E.DepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
