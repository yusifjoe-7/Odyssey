using FluentValidation;

namespace Odyssey.Application.Users.Registering;

public class RegisteringCommandValidation : AbstractValidator<RegisteringCommand>
{
    public RegisteringCommandValidation()
    {
        RuleFor(u => u.FristName)
            .NotEmpty()
            .WithMessage("Firest name canot be empty")
            .MaximumLength(99)           // thir is a space in the mapping
            .WithMessage("Firest name is too long");

        RuleFor(u => u.SecondName)
            .NotEmpty()
            .WithMessage("Second name canot be empty")
            .MaximumLength(100)
            .WithMessage("Second name is too long");

        RuleFor(u => u.UserName)
            .NotEmpty()
            .WithMessage("UserName canot be empty")
            .MaximumLength(200)
            .WithMessage("UserName is too long");

        RuleFor(u => u.Email).EmailAddress()
        .WithMessage("Email Should be Email");

        RuleFor(u => u.Password)
            .NotEmpty()
            .WithMessage("Password canot be empty")
            .MaximumLength(600)
            .WithMessage("Password is too long")
            .MinimumLength(8)
            .WithMessage("the minimum length is 8 chars");

    }
}
