using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DMProject.Infrastructure.Validators;


namespace DMProject.Models
{
    public class RegistrationViewModel : IValidatableObject
    {
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public string mobile { get; set; }
        public string truename { get; set; }
        public string sex { get; set; }
      

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new RegistrationViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}