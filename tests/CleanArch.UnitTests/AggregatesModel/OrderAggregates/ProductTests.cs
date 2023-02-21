using Bogus;
using CleanArch.Application.AggregatesModel.OrderAggregates;
using FluentAssertions;
using Xunit;

namespace CleanArch.UnitTests.AggregatesModel.OrderAggregates;

/// <summary>
/// Product Entity Test
/// </summary>
public class ProductTests
{
    [Fact]
    public void Should_Instantiate_Product_With_Name()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
    
        // When
        Product product =  Product.NewProduct(name, price);
    
        // Then
        product.Name.Should().Be(name);
    }

    [Fact]
    public void Should_Instantiate_Product_With_Price()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
    
        // When
        Product product =  Product.NewProduct(name, price);
    
        // Then
        product.Price.Should().Be(price);
    }

    [Fact]
    public void Should_Instantiate_Product_With_Generated_Id()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
    
        // When
        Product product =  Product.NewProduct(name, price);
    
        // Then
        product.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_Validate_Product_Name_Must_Not_Be_Empty()
    {
        // Given
        Faker faker = new("en");
        var name = string.Empty;
        var price = faker.Random.Decimal(10m, 100m);
        var productValidator = new ProductValidator();
        Product product =  Product.NewProduct(name, price);
    
        // When
        var validationResult = productValidator.Validate(product);
    
        // Then
        validationResult.Errors.Should().Contain(_ => 
            _.ErrorMessage == "'Name' must not be empty.");
    }

    [Fact]
    public void Should_Validate_Product_Price_Must_Be_Greater_Than_0()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(-10m, -1m);
        var productValidator = new ProductValidator();
        Product product =  Product.NewProduct(name, price);
    
        // When
        var validationResult = productValidator.Validate(product);
    
        // Then
        validationResult.Errors.Should().Contain(_ => 
            _.ErrorMessage == "'Price' must be greater than '0'.");
    }
}
