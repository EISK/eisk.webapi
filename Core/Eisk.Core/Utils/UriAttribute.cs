using System;
using System.ComponentModel.DataAnnotations;

namespace Eisk.Core.Utils
{
    public class UriAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                try
                {
                    // ReSharper disable once ObjectCreationAsStatement
                    new Uri(value.ToString());
                }
                catch (Exception ex)
                {
                    return new ValidationResult(ex.Message);
                }
            }
            return ValidationResult.Success;
        }

    }
}