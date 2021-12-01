using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;

namespace HR_Sys.Models
{
    public class Validations
    {
      
        public int id { get; set; }

        [Required(ErrorMessage = "Please Choose The Group Validations Before Add")]
        public string validationName { get; set; }
        public bool empAdd { get; set; } = false;
        public bool empEdit { get; set; } = false;
        public bool empDelete { get; set; } = false;
        public bool empDisplay { get; set; } = false;
        //general settings
        public bool gsAdd { get; set; } = false;
        public bool gsEdit { get; set; } = false;
        public bool gsDelete { get; set; } = false;
        public bool gsDisplay { get; set; } = false;
        //attend
        public bool attendAdd { get; set; } = false;
        public bool attendEdit { get; set; } = false;
        public bool attendDelete { get; set; } = false;
        public bool attendDisplay { get; set; }= false;
        //report
        public bool reportAdd { get; set; } = false;
        public bool reportEdit { get; set; } = false;
        public bool reportDelete { get; set; } = false;
        public bool reportDisplay { get; set; } = false;

        //relation with hr 
        public virtual ICollection<HR> HRs { get; set; }  

    }
}
