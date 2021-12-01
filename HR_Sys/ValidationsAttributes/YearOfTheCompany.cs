using System.ComponentModel.DataAnnotations;

namespace HR_Sys.ValidationsAttributes
{
    public class YearOfTheCompany: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            value = (DateTime)value;
            var dateOfCompany=new DateTime(2008, 1, 1);
            if (dateOfCompany.CompareTo(value) <= 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("من فضلك ادخل تاريخ تعاقد صحيح");
            }
        }
    }
}
