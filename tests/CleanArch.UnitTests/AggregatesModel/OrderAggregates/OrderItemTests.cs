using Bogus;
using CleanArch.Application.AggregatesModel.OrderAggregates;
using FluentAssertions;
using Xunit;

namespace CleanArch.UnitTests.AggregatesModel.OrderAggregates;

/// <summary>
/// Order Item Entity Tests
/// </summary>
public class OrderItemTests
{
    [Fact]
    public void Should_Instantiate_OrderItem_With_Product()
    {
        // Given
        Faker faker = new("en");

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
    
        // When
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
        
        // Then
        item.Product.Should().NotBeNull();
    }

    [Fact]
    public void Should_Instantiate_OrderItem_With_Quantity()
    {
        // Given
        Faker faker = new("en");

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
    
        // When
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
        
        // Then
        item.Quantity.Should().Be(quantity);
    }

    [Fact]
    public void Should_Instantiate_OrderItem_WithCost_Equal_Price_x_Quantity()
    {
        // Given
        Faker faker = new("en");

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
    
        // When
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
        
        // Then
        item.Cost.Should().Be(price * quantity);
    }

    [Fact]
    public void Should_OrderItem_Be_Able_To_Update_Quantity()
    {
        // Given
        Faker faker = new("en");

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
        var newQuantity = faker.Random.Int(1, 10);
    
        // When
        item.UpdateQuantity(newQuantity);

        // Then
        item.Quantity.Should().Be(newQuantity);
    }

    [Fact]
    public void Should_OrderItem_Update_Cost_When_Update_Quantity()
    {
        // Given
        Faker faker = new("en");

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
        var newQuantity = faker.Random.Int(1, 10);
    
        // When
        item.UpdateQuantity(newQuantity);

        // Then
        item.Cost.Should().Be(price * newQuantity);
    }

    [Fact]
    public void Should_OrderItem_Validate_Quantity_Must_Be_Greater_Than_0()
    {
        // Given
        Faker faker = new("en");
        ProductValidator productValidator = new();
        OrderItemValidator orderItemValidator = new(productValidator);

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(-10, -1);
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
    
        // When
        var validationResults = orderItemValidator.Validate(item);

        // Then
        validationResults.Errors.Should().Contain(_ => 
            _.ErrorMessage == "'Quantity' must be greater than '0'.");
    }

    [Fact]
    public void Should_OrderItem_Validate_Cost_Must_Be_Greater_Than_0()
    {
        // Given
        Faker faker = new("en");
        ProductValidator productValidator = new();
        OrderItemValidator orderItemValidator = new(productValidator);

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(-100m, -10m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
    
        // When
        var validationResults = orderItemValidator.Validate(item);

        // Then
        validationResults.Errors.Should().Contain(_ => 
            _.ErrorMessage == "'Cost' must be greater than '0'.");
    }

    [Fact]
    public void Should_OrderItem_Validate_Product_Name_Must_Not_Be_Empty()
    {
        // Given
        Faker faker = new("en");
        ProductValidator productValidator = new();
        OrderItemValidator orderItemValidator = new(productValidator);

        var name = string.Empty;
        var price = faker.Random.Decimal(10m, 100m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
    
        // When
        var validationResults = orderItemValidator.Validate(item);

        // Then
        validationResults.Errors.Should().Contain(_ => 
            _.ErrorMessage == "'Name' must not be empty.");
    }

    [Fact]
    public void Should_OrderItem_Validate_Product_Price_Must_Be_Greater_Than_0()
    {
        // Given
        Faker faker = new("en");
        ProductValidator productValidator = new();
        OrderItemValidator orderItemValidator = new(productValidator);

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(-100m, -10m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
    
        // When
        var validationResults = orderItemValidator.Validate(item);

        // Then
        validationResults.Errors.Should().Contain(_ => 
            _.ErrorMessage == "'Price' must be greater than '0'.");
    }
}
