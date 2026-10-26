using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48EFCoreSession02.Models
{
    internal class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = null!;
        public ICollection<EmployeeProject> ProjectEmployees { get; set; } = new HashSet<EmployeeProject>();
    }
}
