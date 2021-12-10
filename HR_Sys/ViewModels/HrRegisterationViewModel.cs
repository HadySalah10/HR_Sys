using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;
using HR_Sys.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sys.ViewModels
{
    public class HrRegisterationViewModel
    {
        public int? hrId { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل الاسم ")]

        //[Range(5,20, ErrorMessage = "لا يجب ان يقل عدداالاحرف عن خمسة احرف ولا يزيد عن عشرون حرف ")]
        [StringLength(50)]
        public string fullName { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "من فضلك ادخل اسم مستخدم  ")]
        public string hrUserName { get; set; }

        [Required(ErrorMessage = "من فضبلك ادخل كلمة المرور")]

        [StringLength(20)]
        public string password { get; set; }

        [NotMapped]
        [Compare("password", ErrorMessage = "غير متطابق")]
        public string confirmPassword { get; set; }

        [Remote("checkEmail", "HR", ErrorMessage = "هذا البريد الالكتروني موجود مسبقا ")]

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "بريد الكتروني غير صالح")]
        public string email { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل اسم المجموعة")]

        [ForeignKey("Valids")]
        public int validationId { get; set; }


    }
}
