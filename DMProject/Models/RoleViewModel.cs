using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DMProject.Infrastructure.Validators;

namespace DMProject.Models
{
    public class RoleViewModel : IValidatableObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public int ix { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new RoleViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}