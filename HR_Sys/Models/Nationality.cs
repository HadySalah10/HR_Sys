namespace HR_Sys.Models
{
    public class Nationality:commonprops
    {
        public string nationality_Name { get; set; }

        //relation with employee
        public virtual List <Employee> Employees { get; set; }  

    }
}
