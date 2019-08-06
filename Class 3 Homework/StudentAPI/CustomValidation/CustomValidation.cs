using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI
{
    public class SchoolAgeAttribute : ValidationAttribute
    {
        private int _minAge;
        private int _maxAge;
        public SchoolAgeAttribute(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime birthday = (DateTime)value;
            int age = DateTime.Now.Year - birthday.Year;
            if (age > _minAge && age <= _maxAge)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(GerErrorMessage());
            }
        }

        private string GerErrorMessage()
        {
            return $"The student age must be at least {_minAge} years old and connat be older than {_maxAge}";
        }
    }
}
