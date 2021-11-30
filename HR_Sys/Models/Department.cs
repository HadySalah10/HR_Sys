using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HR_Sys.Models
{
    public class Department :commonprops
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(50, MinimumLength = 5)]
        public string dept_name { get; set; }

        //relation with employee
        public virtual List<Employee> employees { get; set; }

    }
}
