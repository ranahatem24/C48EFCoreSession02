using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48EFCoreSession02.Models
{
    internal class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public DateTime DateofCreation { get; set; }
        public int Serial { get; set; }
        #region Manage Relationship
        //By Convension=>ManagerId,ManagerEmpId,EmployeeId,EmployeeEmpId
        //[ForeignKey("Manager")]
        //[ForeignKey(nameof(Manager))]
        public int? DeptManagerId { get; set; }
        [InverseProperty(nameof(Employee.ManagedDepartment))]
        public Employee Manager { get; set; } = null!;
        #endregion
        #region Work RelationShip
        [InverseProperty(nameof(Employee.EmployeeDepartment))]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        #endregion
    }
}
