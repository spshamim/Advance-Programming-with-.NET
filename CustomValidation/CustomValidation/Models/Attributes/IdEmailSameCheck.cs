using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomValidation.Models.Attributes
{
    public class IdEmailSameCheck:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instance = validationContext.ObjectInstance;
            var idProperty = instance.GetType().GetProperty("Id");
            var emailProperty = instance.GetType().GetProperty("Email");

            if (idProperty != null && emailProperty != null)
            {
                var idValue = idProperty.GetValue(instance) as string;
                var emailValue = emailProperty.GetValue(instance) as string;

                if (idValue != null && emailValue != null)
                {
                    var expectedEmail = $"{idValue}@student.aiub.edu";

                    if (emailValue == expectedEmail)
                    {
                        return ValidationResult.Success;
                    }
                }
            }

            return new ValidationResult("The Email must contain the same ID as the Id and in XX-YYYYY-Z@student.aiub.edu pattern.");
        }
    }
}