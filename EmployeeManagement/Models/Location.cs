using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Grid { get; set; }
        public int Servo1 { get; set; }
        public int Servo2 { get; set; }
        public int Servo3 { get; set; }
        public int Servo4 { get; set; }
        public int Servo5 { get; set; }
        public int Servo6 { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
    }
}
