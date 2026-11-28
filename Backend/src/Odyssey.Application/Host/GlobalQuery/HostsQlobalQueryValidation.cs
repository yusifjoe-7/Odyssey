using FluentValidation;

namespace Odyssey.Application.Host.GlobalQuery;

public class HostsQlobalQueryValidation : AbstractValidator<HostsQlobalQuery>
{
    public HostsQlobalQueryValidation()
    {
        RuleFor(q => q.NumberOfPages)
            .GreaterThanOrEqualTo(5)
            .WithMessage("NumberOfPages must be >= 5");
    }
}
