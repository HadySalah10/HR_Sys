
using HR_Sys.Models.BaseIDEntity;

namespace HR_Sys.Models
{
    public class VacationType : CommonProps
    {
        public string vacationName { get; set; }

        //relation with vacation_type-emp table
        public virtual ICollection<TypesOfVacationsEmp> TypesOfVacationsEmps { get; set; }

    }
}
