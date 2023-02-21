using FluentValidation;

namespace CleanArch.Application.AggregatesModel.OrderAggregates;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator(IValidator<Address> addressValidator)
    {
        RuleFor(customer => customer.Id).NotEmpty();
        RuleFor(customer => customer.FirstName).NotEmpty();
        RuleFor(customer => customer.ShippingAddress).SetValidator(addressValidator);
    }
}

