using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48EFCoreSession02.Models
{
    internal class Employee
    {
  
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }

        public string Email { get; set; }
       

        public string? Password { get; set; }
       
        public string PhoneNumber { get; set; }
      
        public string UserName { get; }
        #region Manage Relationship
        //Navigation Property => [One]
        [InverseProperty(nameof(Department.Manager))]
       public Department? ManagedDepartment { get; set; }
        #endregion
        #region Employee With Address
        public Address EmployeeAddress { get; set; } = null!;
        #endregion
        #region Works On RelationShip
        //[ForeignKey(nameof(EmployeeDepartment))]
        public int DepartmentId { get; set; }
        [InverseProperty(nameof(Department.Employees))]
        public Department EmployeeDepartment { get; set; } = null!;
        #endregion
        #region EmployeeProject RelationShip
        [InverseProperty(nameof(EmployeeProject.Employee))]
        public EmployeeProject? EmployeeProject { get; set; }
        #endregion
    }
}
