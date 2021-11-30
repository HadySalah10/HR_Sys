using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models
{
    public class Emp_Phones
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }

        //relation with employee
        [ForeignKey("Employees")]
        public int emp_id { get; set; }
        public virtual Employee Employees { get; set; }


    }
}
