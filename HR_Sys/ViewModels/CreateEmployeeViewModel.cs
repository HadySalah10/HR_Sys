using HR_Sys.ValidationsAttributes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public int EmployeeID { get; set; }

        //اسم الموظف 
        [DisplayName("اسم الموظف")]

        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 5)]
        public string empName { get; set; }

        //عنوان الموظف 
        [DisplayName("العنوان")]
        [Required(ErrorMessage = "رجاء ادخل عنوان الموظف")]
        [StringLength(150)]
        public string empAddress { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [StringLength(11, ErrorMessage = "من فضلك ادخل رقم تليفون صحيح")]

        // رقم تليفون الموظف 
        [DisplayName("رقم التليفون")]
        [DataType(DataType.PhoneNumber)]

        public string phoneNum { get; set; }
        // رقم تليفون2 الموظف 
        [DataType(DataType.PhoneNumber)]


        [DisplayName("رقم تليفون اخر")]

        public string? phoneNum2 { get; set; }

        // 1 for male 0 for female

        [Required(ErrorMessage = "النوع مطلوب")]
        [DisplayName("النوع")]


        public bool empGender { get; set; }
        [DisplayName("الجنسية")]

        // الجنسيه
        public int nationalityId { get; set; }

        // تاريخ الميلاد
        [DisplayName("تاريخ الميلاد")]

        [Required(ErrorMessage = "تاريخ الميلاد مطلوب")]
        [Within20Years]
        public DateTime empDateOfBirth { get; set; }

        // الرقم القومي  

        [Required(ErrorMessage = "يجب ادخال الرقم القومي")]
        [Remote("checkSsn", "Employee", ErrorMessage = "هذا الرقم موجود مسبقا")]

        [StringLength(14, ErrorMessage = "يجب ادخال 14 رقم")]

        [ServiceStack.DataAnnotations.Unique]
        [DisplayName("الرقم القومي")]

        public string empSsn { get; set; }

        // تاريخ التعاقد


        [Required(ErrorMessage = "برجاء ادخال تاريخ التعاقد")]
        [YearOfTheCompany]
        [DisplayName("تاريخ التعاقد")]

        public DateTime empHireDate { get; set; }



        //  الراتب الاساسي

        [Required(ErrorMessage = "برجاء ادخال الراتب الاساسي")]
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = " من فضلك ادخل راتب صحيح")]
        [DisplayName("الراتب الاساسي")]

        public double? empNetSalary { get; set; }
        //  مصاريف اضافية 
        [DisplayName("مصاريف اضافية")]

        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = " من فضلك ادخل راتب صحيح")]
        public double? empNonNetSalary { get; set; }
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = " من فضلك ادخل راتب صحيح")]
        //  الراتب الكلي 
        [DisplayName("الراتب الكلي")]

        public double? empGrossSalary { get; set; }



        //   time supposed to be in work  
        [DisplayName("موعد الحضور")]
        [DataType(DataType.Time)]

        [Required(ErrorMessage = "برجاء ادخال ميعاد بدء العمل")]
        public DateTime requiredAttendanceTime { get; set; }
        //   time supposed to be end of his/her base  time  
        [DisplayName("موعد الانصراف")]
        [DataType(DataType.Time)]


        [Required(ErrorMessage = " برجاء ادخال ميعاد انتهاء العمل")]
        public DateTime requiredDepartureTime { get; set; }
        [Required(ErrorMessage = "هذه الخانة مطلوبه")]

        [DisplayName("السعر/بالساعة")]
        [DataType(DataType.Currency)]

        public decimal? requiredSalaryPerHour { get; set; }
        [Required(ErrorMessage = "رجاء ادخل هذا الحقل")]
        [DisplayName("عدد الايام/بالشهر")]
        [RegularExpression("([0-9]+)", ErrorMessage = "رجاء ادخل هذا الحقل بشكل صحيح ")]

        public int? requiredDaysPerMonth { get; set; }

        // مش موجود في ال srs
        //relation with department
        [ForeignKey("Department")]
        [DisplayName("القسم")]
        [Required(ErrorMessage = "يجب ادخال القسم")]

        public int deptid { get; set; }

    }

   
}
