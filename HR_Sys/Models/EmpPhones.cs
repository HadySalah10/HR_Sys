using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;


namespace HR_Sys.Models
{
    public class EmpPhones:CommonProps
    {

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(11,11,ErrorMessage = "من فضلك ادخل رقم تليفون صحيح")]
        public string PhoneNumber { get; set; }

        //relation with employee
        [ForeignKey("Employees")]
        public int empId { get; set; }
        public virtual Employee Employees { get; set; }


    }
}
