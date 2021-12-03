using HR_Sys.Models.BaseIDEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HR_Sys.Models
{
    public class Department :CommonProps
    {
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 5)]
        public string deptName { get; set; } 
   

        //relation with employee
        public virtual ICollection<Employee> employees { get; set; }

    }
}
