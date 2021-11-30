namespace HR_Sys.Models
{
    public class Department :commonprops
    {
        public string dept_name { get; set; }

        //relation with employee
        public virtual List<Employee> employees { get; set; }

    }
}
