using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models
{
    public class Validations
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please Choose The Group Validations Before Add")]
        public string validation_name { get; set; }
        public bool? emp_add { get; set; }
        public bool? emp_edit { get; set; }
        public bool? emp_delete { get; set; }
        public bool? emp_display { get; set; }
        //general settings
        public bool? gs_add { get; set; }
        public bool? gs_edit { get; set; }
        public bool? gs_delete { get; set; }
        public bool? gs_display { get; set; }
        //attend
        public bool? attend_add { get; set; }
        public bool? attend_edit { get; set; }
        public bool? attend_delete { get; set; }
        public bool? attend_display { get; set; }
        //report
        public bool? report_add { get; set; }
        public bool? report_edit { get; set; }
        public bool? report_delete { get; set; }
        public bool? report_display { get; set; }

        //relation with hr 
        public virtual List <HR> HRs { get; set; }  

    }
}
