using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HR_Sys.ViewModels
{
    public class CreateDepartmentViewModel
    {
        
        public int deptId { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 5)]
        [DisplayName("اسم القسم")]

        public string deptName { get; set; }
    }
}
