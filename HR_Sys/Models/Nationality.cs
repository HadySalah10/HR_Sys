using HR_Sys.Models.BaseIDEntity;

namespace HR_Sys.Models
{
    public class Nationality: CommonProps
    {
        public string nationalityName { get; set; }

        //relation with employee
        public virtual ICollection<Employee> Employees { get; set; }  

    }
}
