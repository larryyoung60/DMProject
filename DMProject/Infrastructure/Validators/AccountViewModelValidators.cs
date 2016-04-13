using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DMProject.Models;
using FluentValidation;

namespace DMProject.Infrastructure.Validators
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(r => r.email).NotEmpty().EmailAddress()
                .WithMessage("Invalid email address");

            RuleFor(r => r.name).NotEmpty()
                .WithMessage("Invalid username");

            RuleFor(r => r.password).NotEmpty()
                .WithMessage("Invalid password");

            RuleFor(r => r.name).NotEmpty()
                .WithMessage("Invalid username");


        }
    }

    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(r => r.name).NotEmpty()
                .WithMessage("Invalid username");

            RuleFor(r => r.password).NotEmpty()
                .WithMessage("Invalid password");
        }
    }

    public class RoleViewModelValidator : AbstractValidator<RoleViewModel>
    {
        public RoleViewModelValidator()
        {
            RuleFor(r => r.id);
            RuleFor(r => r.name).NotEmpty().Length(1,50).WithMessage("Name must be 1-50 char");
            RuleFor(r => r.code);
            RuleFor(r => r.description);
            RuleFor(r => r.status);
            RuleFor(r => r.ix);


        }
    }
}