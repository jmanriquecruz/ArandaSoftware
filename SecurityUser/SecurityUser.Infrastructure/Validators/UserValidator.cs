using FluentValidation;
using SecurityUser.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityUser.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.Age).NotNull().InclusiveBetween(18, 80);
        }
    }
}
