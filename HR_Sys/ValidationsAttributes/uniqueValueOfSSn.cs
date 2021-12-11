using HR_Sys.Models;
using System.ComponentModel.DataAnnotations;

namespace HR_Sys.ValidationsAttributes
{
    public class uniqueValueOfSSn: ValidationAttribute
    {
        HrDBContext _db;
        public uniqueValueOfSSn(HrDBContext db)
        {
            _db = db;

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            // Here goes the code for creating DbContext, For testing I created List<string>
            // DbContext db = new DbContext();
            value = value;

            var ssn = _db.Employees.FirstOrDefault(u => u.empSsn.Contains(value.ToString()));

                if (String.IsNullOrEmpty(ssn.empSsn))
                    return ValidationResult.Success;
                else
                    return new ValidationResult(ssn.empName+" هذا الرقم موجود مسبقا بأسم");
            

        }
    }
}
