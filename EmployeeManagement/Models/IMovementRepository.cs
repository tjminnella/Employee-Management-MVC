using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public interface IMovementRepository
    {
        Movement GetMovement(int Id);
        IEnumerable<Movement> GetAllMovements();
        Movement Add(Movement movement);
        Movement Update(Movement employeeChanges);
        Movement Delete(int Id);
    }
}
