using FluentValidation;

namespace CleanArch.Application.AggregatesModel.OrderAggregates;

public class OrderItemValidator : AbstractValidator<OrderItem>
{
    public OrderItemValidator(IValidator<Product> productValidator)
    {
        RuleFor(orderItem => orderItem.Id).NotEmpty();
        RuleFor(orderItem => orderItem.Quantity).GreaterThan(0);
        RuleFor(orderItem => orderItem.Cost).GreaterThan(0);
        RuleFor(orderItem => orderItem.Product).SetValidator(productValidator);
    }
}
