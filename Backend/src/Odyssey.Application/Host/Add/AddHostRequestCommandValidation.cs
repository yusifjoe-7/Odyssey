using FluentValidation;

namespace Odyssey.Application.Host.Add;

public class AddHostRequestCommandValidation : AbstractValidator<AddHostRequestCommand>
{
    public AddHostRequestCommandValidation()
    {
        RuleFor(c => c.OwnerUserName)
            .NotEmpty()
            .WithMessage("OwnerUserName canot be empty")
            .MaximumLength(200)
            .WithMessage("OwnerUserName is too long");

        RuleFor(c => c.Description)
            .NotEmpty()
            .WithMessage("Description canot be empty")
            .MaximumLength(1000)
            .WithMessage("Description is too long");

        RuleFor(c => c.PricePerNight)
            .GreaterThanOrEqualTo(0)
            .WithMessage("PricePerNight canot be negative");

        RuleFor(c => c.PropertyArea)
            .GreaterThanOrEqualTo(0)
            .WithMessage("PropertyArea canot be negative");

        RuleFor(c => c.MainImageKey)
            .NotNull()
            .WithMessage("MainImageKey canot be empty");

        RuleFor(c => c.HostImages)
            .NotNull()
            .WithMessage("HostImages canot be null");
    }
}
