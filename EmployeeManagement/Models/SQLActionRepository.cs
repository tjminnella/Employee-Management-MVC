using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Models
{
    public class SQLActionRepository : IActionRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<SQLEmployeeRepository> logger;

        public SQLActionRepository(AppDbContext context,
                                    ILogger<SQLEmployeeRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public Action Add(Action location)
        {
            context.Actions.Add(location);
            context.SaveChanges();
            return location;
        }

        public Action Delete(int Id)
        {
            Action location = context.Actions.Find(Id);
            if (location != null)
            {
                context.Remove(location);
                context.SaveChanges();
            }

            return location;
        }

        public IEnumerable<Action> GetAllActions()
        {
            return context.Actions;
        }

        public Action GetAction(int Id)
        {
            return context.Actions.Find(Id);
        }

        public Action Update(Action locationChanges)
        {
            var location = context.Actions.Attach(locationChanges);
            location.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return locationChanges;

        }
    }
}
