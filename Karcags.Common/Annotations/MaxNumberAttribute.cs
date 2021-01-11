using System;
using System.ComponentModel.DataAnnotations;

namespace Karcags.Common.Annotations
{
    /// <summary>
    /// Maximum number checked annotation
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxNumberAttribute : ValidationAttribute
    {
        private int Max { get; set; }

        /// <summary>
        /// Add annotation
        /// </summary>
        /// <param name="max">Max value parameter</param>
        public MaxNumberAttribute(int max)
        {
            this.Max = max;
        }

        /// <summary>
        /// Check current value is valid or not
        /// </summary>
        /// <param name="value">Checked value</param>
        /// <param name="validationContext">Context</param>
        /// <returns>Validation result</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                // Try convert to nullable int
                int? number = (int?)value;

                // Ignore null values
                if (number == null)
                {
                    return ValidationResult.Success;
                }

                // Check maximum (explicit)
                if (number > this.Max)
                {
                    return new ValidationResult($"Value is bigger than {this.Max}");
                }
            }
            catch (Exception)
            {
                return new ValidationResult("Field is not integer");
            }

            return ValidationResult.Success;
        }
    }
}