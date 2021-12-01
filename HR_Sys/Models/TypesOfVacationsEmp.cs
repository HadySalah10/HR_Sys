using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;

namespace HR_Sys.Models
{
    public class TypesOfVacationsEmp: CommonProps
    {

        public int empId { get; set; }


        public int vacId { get; set; }

        //object from employee
        public Employee emp { get; set; }

        //object from vacation
        public VacationType VacationType { get; set; }

        public DateTime? date { get; set; }





    }
}
