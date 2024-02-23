using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class LocationViewModel
    {
        public Location Location { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public string PageTitle { get; set; }
    }
}
