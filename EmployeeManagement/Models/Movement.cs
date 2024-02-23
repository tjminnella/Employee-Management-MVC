using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Movement
    {
		public int MovementID { get; set; }
		[Required]
		public int Action { get; set; }
		[Required]
		public int MovementNumber { get; set; }
		[Required]
		public int Location { get; set; }
		[Required]
		public double WaitBeforeSeconds { get; set; }
		[Required]
		public double WaitAfterSeconds { get; set; }
		[Required]
		public bool Active { get; set; }
	}
}
