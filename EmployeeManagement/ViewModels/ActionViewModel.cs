using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class ActionViewModel
    {
        public EmployeeManagement.Models.Action Action { get; set; }
        public IEnumerable<EmployeeManagement.Models.Action> Actions { get; set; }
        public string PageTitle { get; set; }

    }
}
