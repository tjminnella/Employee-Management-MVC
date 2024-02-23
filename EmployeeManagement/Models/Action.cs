using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Action
    {
        public int ActionID { get; set; }
        [Required]
        [Display(Name = "Action Name")]
        [StringLength(40)]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Desription { get; set; }
        public virtual ICollection<Movement> Movements { get; set; }

    }
}
