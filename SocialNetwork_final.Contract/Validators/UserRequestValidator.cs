using FluentValidation;
using Microsoft.Identity.Client;
using SocialNetwork_final.Contract;
using SocialNetwork_final.Contract.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_final.Contract.Validator
{
    public class UserRequestValidator: AbstractValidator<UserRequest>
    {
        public UserRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
