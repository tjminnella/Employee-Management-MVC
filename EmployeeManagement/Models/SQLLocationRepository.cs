using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Models
{
    public class SQLLocationRepository : ILocationRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<SQLEmployeeRepository> logger;

        public SQLLocationRepository(AppDbContext context,
                                    ILogger<SQLEmployeeRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public Location Add(Location location)
        {
            context.Locations.Add(location);
            context.SaveChanges();
            return location;
        }

        public Location Delete(int Id)
        {
            Location location = context.Locations.Find(Id);
            if (location != null)
            {
                context.Remove(location);
                context.SaveChanges();
            }

            return location;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return context.Locations;
        }

        public Location GetLocation(int Id)
        {
            return context.Locations.Find(Id);
        }

        public Location Update(Location locationChanges)
        {
            var location = context.Locations.Attach(locationChanges);
            location.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return locationChanges;

        }
    }
}
