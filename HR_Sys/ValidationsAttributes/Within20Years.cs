using System.ComponentModel.DataAnnotations;

namespace HR_Sys
{
    public class Within20Years: ValidationAttribute
    {
       
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                value = (DateTime)value;
                if (DateTime.Now.AddYears(-20).CompareTo(value) >= 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(" يجب الا يقل عمر الموظف عن 20 سنة");
                }
            }
        
    }
}
