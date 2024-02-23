using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class MovementViewModal
    {
        public Movement Movement { get; set; }
        public IEnumerable<Movement> Movements { get; set; }
        public string PageTitle { get; set; }
    }
}
