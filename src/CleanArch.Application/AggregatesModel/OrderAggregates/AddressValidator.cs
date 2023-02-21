using FluentValidation;

namespace CleanArch.Application.AggregatesModel.OrderAggregates;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(address => address.Street).NotEmpty();
        RuleFor(address => address.State).NotEmpty();
        RuleFor(address => address.City).NotEmpty();
        RuleFor(address => address.ZipCode).NotEmpty();
    }
}

