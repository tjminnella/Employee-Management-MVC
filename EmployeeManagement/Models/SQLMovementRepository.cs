using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Models
{
    public class SQLMovementRepository : IMovementRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<SQLEmployeeRepository> logger;

        public SQLMovementRepository(AppDbContext context,
                                    ILogger<SQLEmployeeRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public Movement Add(Movement movement)
        {
            context.Movements.Add(movement);
            context.SaveChanges();
            return movement;
        }

        public Movement Delete(int Id)
        {
            Movement movement = context.Movements.Find(Id);
            if (movement != null)
            {
                context.Remove(movement);
                context.SaveChanges();
            }
            return movement;
        }

        public IEnumerable<Movement> GetAllMovements()
        {
            return context.Movements;
        }

        public Movement GetMovement(int Id)
        {
            return context.Movements.Find(Id);
        }

        public Movement Update(Movement movementChanges)
        {
            var movement = context.Movements.Attach(movementChanges);
            movement.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return movementChanges;

        }
    }
}
