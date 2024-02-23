using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockActionRepository : IActionRepository
    {
        private List<Action> _ActionList;

        public MockActionRepository()
        {
            _ActionList = new List<Action>()
            { 
                new Action(){ActionID = 1, Name="First Action", Desription="My First Action" },
                new Action(){ActionID = 2, Name="Second Action", Desription="My Second Action"},
                new Action(){ActionID = 3, Name="Third Action", Desription="My Third Action" }
            };
        }

        public Action Add(Action action)
        {
            action.ActionID = _ActionList.Max(e => e.ActionID) + 1;
            _ActionList.Add(action);
            return action;
        }

        public Action Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Action> GetAllActions()
        {
            return _ActionList;
        }

        public Action Update(Action employeeChanges)
        {
            throw new NotImplementedException();
        }

        Action IActionRepository.GetAction(int Id)
        {
            return _ActionList.FirstOrDefault(e => e.ActionID == Id);
        }
    }
}
