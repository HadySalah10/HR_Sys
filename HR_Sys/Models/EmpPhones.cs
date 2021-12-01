using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;


namespace HR_Sys.Models
{
    public class EmpPhones:CommonProps
    {

        [Required(ErrorMessage ="Please Enter your Phone Number")]
        [Range(11,11,ErrorMessage ="Please Enter a Vaild Phone Number")]
        public string PhoneNumber { get; set; }

        //relation with employee
        [ForeignKey("Employees")]
        public int empId { get; set; }
        public virtual Employee Employees { get; set; }


    }
}
