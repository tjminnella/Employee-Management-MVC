using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockMovementRepository : IMovementRepository
    {
        private List<Movement> _movementList;

        public MockMovementRepository()
        {
            _movementList = new List<Movement>()
            { 
                new Movement(){MovementID = 1, Action = 1, MovementNumber = 1, Location = 1, WaitBeforeSeconds = 1.2, WaitAfterSeconds = .34 },
                new Movement(){MovementID = 2, Action = 1, MovementNumber = 1, Location = 2, WaitBeforeSeconds = 1.2, WaitAfterSeconds = .34 },
                new Movement(){MovementID = 3, Action = 1, MovementNumber = 1, Location = 3, WaitBeforeSeconds = 1.2, WaitAfterSeconds = .34 },
                new Movement(){MovementID = 4, Action = 1, MovementNumber = 1, Location = 4, WaitBeforeSeconds = 1.2, WaitAfterSeconds = .34 }
            };
        }

        public Movement Add(Movement movement)
        {
            movement.MovementID = _movementList.Max(e => e.MovementID) + 1;
            _movementList.Add(movement);
            return movement;
        }

        public Movement Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movement> GetAllMovements()
        {
            return _movementList;
        }

        public Movement GetMovement(int Id)
        {
            return _movementList.FirstOrDefault(e => e.MovementID == Id);
        }

        public Movement Update(Movement employeeChanges)
        {
            throw new NotImplementedException();
        }
    }
}
