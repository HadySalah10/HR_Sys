

namespace HR_Sys.Models
{
    public class Vacation_Type : commonprops
    {
        public string vacation_name { get; set; }

        //relation with vacation_type-emp table
        public virtual List <Types_Of_Vacations_emp> Types_Of_Vacations_Emps { get; set; }

    }
}
