using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomValidation.Models.Attributes
{
    public class AtLeastOneItemAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is List<string> list && list.Count > 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("At least one Hobby must be selected.");
        }
    }

}