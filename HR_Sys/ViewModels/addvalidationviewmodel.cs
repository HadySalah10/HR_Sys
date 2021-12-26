using System.ComponentModel.DataAnnotations;

namespace HR_Sys.ViewModels
{
    public class addvalidationviewmodel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المجموعة")]
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
        public bool attendDisplay { get; set; } = false;
        //report
        public bool reportAdd { get; set; } = false;
        public bool reportEdit { get; set; } = false;
        public bool reportDelete { get; set; } = false;
        public bool reportDisplay { get; set; } = false;
    }
}
