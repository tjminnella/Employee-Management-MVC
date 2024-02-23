using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = 1,
                        Name = "Mary",
                        Department = Dept.IT,
                        Email = "mary@RobotNeighbor.com"
                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "John",
                        Department = Dept.HR,
                        Email = "john@RobotNeighbor.com"
                    }
                );

            modelBuilder.Entity<Action>().HasData(
                  new Action
                  {
                      ActionID = 1,
                      Name = "ServoTest1",
                      Desription = "This is my first servo test"
                  },

              new Action
              {
                  ActionID = 2,
                  Name = "ServoTest2",
                  Desription = "This is my second servo test"
              }
                  );

            /*INSERT INTO location values(1, 0, 0, 0, 0, 120, 110, 0, 90, 90, 90, 'Resting');
            INSERT INTO location values(2, 0, 0, 0, 0, 120, 120, 45, 0, 0, 0, '' );
            INSERT INTO location values(3, 0, 0, 0, 0, 120, 120, 0, 180, 180, 180, '' );
            INSERT INTO location values(4, 0, 0, 0, 0, 120, 120, 45, 0, 0, 0, '' );
            INSERT INTO location values(5, 0, 0, 0, 0, 120, 120, 0, 90, 90, 0, '' );
            INSERT INTO location values(6, 0, 0, 0, 0, 120, 110, 0, 180, 90, 180, '' );
            INSERT INTO location values(7, 0, 0, 0, 0, 120, 110, 0, 0, 90, 180, '' );
            INSERT INTO location values(8, 0, 0, 0, 0, 120, 110, 0, 90, 90, 180, '' );
            INSERT INTO location values(9, 0, 0, 0, 0, 120, 110, 0, 90, 0, 180, '' );
            INSERT INTO location values(10, 0, 0, 0, 0, 120, 110, 0, 90, 180, 180, '' );*/

            modelBuilder.Entity<Location>().HasData(
                  new Location
                  {
                      LocationID = 1,
                      X = 0,
                      Y = 0,
                      Z = 0,
                      Grid = 0,
                      Servo1 = 120,
                      Servo2 = 110,
                      Servo3 = 0,
                      Servo4 = 90,
                      Servo5 = 90,
                      Servo6 = 90,
                      Description = "Resting"
                  },
                  new Location
                  {
                      LocationID = 2,
                      X = 0,
                      Y = 0,
                      Z = 0,
                      Grid = 0,
                      Servo1 = 120,
                      Servo2 = 120,
                      Servo3 = 45,
                      Servo4 = 0,
                      Servo5 = 0,
                      Servo6 = 0
                  }
                  );


            /*INSERT INTO movement values(1, 1, 1, 1, 0, 1);
            INSERT INTO movement values(1, 2, 2, 1, 0, 1);
            INSERT INTO movement values(1, 3, 3, 1, 0, 1);
            INSERT INTO movement values(1, 4, 4, 1, 0, 1);
            INSERT INTO movement values(1, 5, 3, 1, 0, 1);
            INSERT INTO movement values(1, 6, 4, 1, 0, 1);
            INSERT INTO movement values(1, 7, 5, 1, 0, 1);
            INSERT INTO movement values(1, 8, 6, 1, 0, 1);
            INSERT INTO movement values(1, 9, 7, 0.5, 0, 1);
            INSERT INTO movement values(1, 10, 6, 0.5, 0, 1);
            INSERT INTO movement values(1, 11, 6, 0.5, 0, 1);
            INSERT INTO movement values(1, 12, 6, 0.5, 0, 1);
            INSERT INTO movement values(1, 13, 8, 0.5, 0, 1);
            INSERT INTO movement values(1, 14, 7, 0.5, 0, 1);
            INSERT INTO movement values(1, 15, 8, 0.5, 0, 1);
            INSERT INTO movement values(1, 16, 8, 0.5, 0, 1);
            INSERT INTO movement values(1, 17, 8, 0.5, 0, 1);
            INSERT INTO movement values(1, 18, 8, 0.5, 0, 1);
            INSERT INTO movement values(1, 19, 8, 0.5, 0, 1);
            INSERT INTO movement values(1, 10, 8, 0.5, 0, 1);*/

            modelBuilder.Entity<Movement>().HasData(
                  new Movement
                  {
                      MovementID = 1,
                      Action = 1,
                      MovementNumber = 1,
                      Location = 1,
                      WaitBeforeSeconds = 0.5,
                      WaitAfterSeconds = 0.5,
                      Active = true
                  },
                  new Movement
                  {
                      MovementID = 2,
                      Action = 2,
                      MovementNumber = 1,
                      Location = 1,
                      WaitBeforeSeconds = 0.5,
                      WaitAfterSeconds = 0.5,
                      Active = true
                  }
                  );
        }
    }
}
