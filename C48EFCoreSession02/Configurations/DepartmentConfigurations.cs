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
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> D)
        {
            D.ToTable("Departments", "Sales");
            D.HasKey(D => D.DeptId);
            D.Property(D => D.DeptId).UseIdentityColumn(10, 10);

            D.Property(D => D.DeptName)
                .HasColumnName("DepartmentName")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired(false)
                .HasDefaultValue("HR");
            D.Property(D => D.DateofCreation)
               .HasDefaultValueSql("GETDATE()");
            D.Ignore(D => D.Serial);

            #region Manage RelationShip
            D.HasOne(E => E.Manager)
                .WithOne(D => D.ManagedDepartment)
                .HasForeignKey<Department>(D => D.DeptManagerId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

        }
    }
}
