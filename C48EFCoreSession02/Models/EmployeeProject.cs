using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48EFCoreSession02.Models
{
    internal class EmployeeProject
    {
        [ForeignKey(nameof(Employee))]
        public int EmpId { get; set; }
        public Employee Employee { get; set; } = null!;
        [ForeignKey(nameof(Project))]
        public int ProId { get; set; }
        public Project Project { get; set; } = null!;
    }
}
