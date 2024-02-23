using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockLocationRepository : ILocationRepository
    {
        private List<Location> _locationList;

        public MockLocationRepository()
        {
            _locationList = new List<Location>() {
                new Location { LocationID = 1, X = 23, Y = 25, Z = 54, Grid = 0, Servo1 = 45, Servo2 = 43, Servo3 = 43, Servo4 = 34, Servo5 = 56, Servo6 = 56, Description = "Resting"},
                new Location { LocationID = 2, X = 23, Y = 25, Z = 54, Grid = 0, Servo1 = 45, Servo2 = 43, Servo3 = 43, Servo4 = 34, Servo5 = 56, Servo6 = 56},
                new Location { LocationID = 3, X = 23, Y = 25, Z = 54, Grid = 0, Servo1 = 45, Servo2 = 43, Servo3 = 43, Servo4 = 34, Servo5 = 56, Servo6 = 56},
                new Location { LocationID = 4, X = 23, Y = 25, Z = 54, Grid = 0, Servo1 = 45, Servo2 = 43, Servo3 = 43, Servo4 = 34, Servo5 = 56, Servo6 = 56},
                new Location { LocationID = 5, X = 23, Y = 25, Z = 54, Grid = 0, Servo1 = 45, Servo2 = 43, Servo3 = 43, Servo4 = 34, Servo5 = 56, Servo6 = 56}
            };
        }

        public Location Add(Location location)
        {
            location.LocationID = _locationList.Max(e => e.LocationID) + 1;
            _locationList.Add(location);
            return location;
        }

        public Location Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _locationList;
        }

        public Location Update(Location employeeChanges)
        {
            throw new NotImplementedException();
        }

        Location ILocationRepository.GetLocation(int Id)
        {
            return _locationList.FirstOrDefault(e => e.LocationID == Id);
        }
    }
}
