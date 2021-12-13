using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.ValidationsAttributes;


namespace HR_Sys.ViewModels
{
    public class EmpGeneralSettingViewModel
    {

             public int id { get; set; }

            [DisplayName(" ساعات الاضافة/ساعة اضافية لكل ساعة اضافة")]
            [Required(ErrorMessage = "يجب ادخال عدد ساعات الاضافة؟")]
            public float requiredExtraHours { get; set; }
            [DisplayName("ساعات الخصم/ساعة مخصومة")]

            [Required(ErrorMessage = "يجب ادخال عدد  ساعات الخصم لكل ساعة خصم")]
            public float requiredDeductHours { get; set; }
            [DisplayName("يوم الاجازة الرسمي 1")]
            [Required(ErrorMessage = "يجب ادخال يوم الاجازة الرسمي ")]

            public int idDayHolday1 { get; set; }
            [DisplayName("يوم الاجازة الرسمي 2")]
            //[Required(ErrorMessage = "يجب ادخال يوم الاجازة الرسمي ")]

            public int idDayHolday2 { get; set; }
    }
}
