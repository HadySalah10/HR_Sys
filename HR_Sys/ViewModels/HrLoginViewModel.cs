using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;
using Microsoft.AspNetCore.Mvc;


namespace HR_Sys.ViewModels
{
    public class HrLoginViewModel
    {
        //[Remote("checkEmail", "HR", ErrorMessage = "هذا البريد الالكتروني موجود مسبقا ")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "بريد الكتروني غير صالح")]
        public string email { get; set; }


        [Required(ErrorMessage = "من فضبلك ادخل كلمة المرور")]

        [StringLength(20)]
        public string password { get; set; }
        [NotMapped]
        public bool Remember { get; set; }
    }
}
