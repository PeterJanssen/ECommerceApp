using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API.Helpers.Shared.FileHandlers
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file == null)
            {
                return new ValidationResult($"No file was found.");
            }

            if (file.Length > _maxFileSize)
            {
                return new ValidationResult($"Maximum allowed file size is { _maxFileSize} bytes.");
            }

            return ValidationResult.Success;
        }
    }
}