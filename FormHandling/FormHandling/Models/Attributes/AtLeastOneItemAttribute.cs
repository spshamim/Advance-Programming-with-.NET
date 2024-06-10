using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FormHandling.Models.Attributes
{
    public class AtLeastOneItemAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is List<string> list && list.Count > 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("At least one item must be selected.");
        }
    }

}