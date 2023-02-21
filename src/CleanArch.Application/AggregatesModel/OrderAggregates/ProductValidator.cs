using FluentValidation;

namespace CleanArch.Application.AggregatesModel.OrderAggregates;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name).NotEmpty();
        RuleFor(product => product.Price).GreaterThan(0);
    }
}