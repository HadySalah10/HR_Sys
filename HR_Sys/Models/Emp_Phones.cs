using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models
{
    public class Emp_Phones
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter your Phone Number")]
        [Range(11,11,ErrorMessage ="Please Enter a Vaild Phone Number")]
        public string PhoneNumber { get; set; }

        //relation with employee
        [ForeignKey("Employees")]
        public int emp_id { get; set; }
        public virtual Employee Employees { get; set; }


    }
}
