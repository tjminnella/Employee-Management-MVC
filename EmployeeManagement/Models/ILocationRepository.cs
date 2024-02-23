using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public interface ILocationRepository
    {
        Location GetLocation(int Id);
        IEnumerable<Location> GetAllLocations();
        Location Add(Location location);
        Location Update(Location employeeChanges);
        Location Delete(int Id);
    }
}
