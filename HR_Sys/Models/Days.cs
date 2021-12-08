using HR_Sys.Models.BaseIDEntity;

namespace HR_Sys.Models
{
    public class Days: CommonProps
    {
        public string daysName { get; set; } 

        public virtual ICollection<TypesOfVacationsEmp> TypesOfVacationsEmps { get; set; }
        //dummy edit

    }
}
