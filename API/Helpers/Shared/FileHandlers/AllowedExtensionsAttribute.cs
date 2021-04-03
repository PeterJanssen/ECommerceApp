using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;


namespace API.Helpers.Shared.FileHandlers
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file == null)
            {
                return new ValidationResult($"No file was found.");
            }

            var extension = Path.GetExtension(file.FileName);
            if (extension != null && !_extensions.Contains(extension.ToLower()))
            {
                return new ValidationResult($"This file extension is not allowed!");
            }

            return ValidationResult.Success;
        }
    }
}