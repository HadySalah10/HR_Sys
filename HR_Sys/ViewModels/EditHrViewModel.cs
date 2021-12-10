using HR_Sys.ValidationsAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HR_Sys.ViewModels
{
    public class EditHrViewModel
    {
        public int? hrId { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل الاسم ")]

        //[Range(5,20, ErrorMessage = "لا يجب ان يقل عدداالاحرف عن خمسة احرف ولا يزيد عن عشرون حرف ")]
        [StringLength(50)]
        public string fullName { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "من فضلك ادخل اسم مستخدم  ")]
        public string hrUserName { get; set; }

 

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "بريد الكتروني غير صالح")]
        public string email { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل اسم المجموعة")]

        [ForeignKey("Valids")]
        public int validationId { get; set; }

    }
}
