using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models
{
    public class Types_Of_Vacations_emp:commonprops
    {

        [Key , Column(Order =1)]
        public int emp_id { get; set; }


        [Key, Column(Order = 2)]
        public int vac_id { get; set; }

        //object from employee
        public Employee emp { get; set; }

        //object from vacation
        public Vacation_Type Vacation_Type { get; set; }

        public DateTime? date { get; set; }





    }
}
