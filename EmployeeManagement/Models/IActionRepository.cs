using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public interface IActionRepository
    {
        Action GetAction(int Id);
        IEnumerable<Action> GetAllActions();
        Action Add(Action action);
        Action Update(Action employeeChanges);
        Action Delete(int Id);
    }
}
