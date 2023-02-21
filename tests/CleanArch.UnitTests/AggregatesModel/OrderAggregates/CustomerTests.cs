using Bogus;
using CleanArch.Application.AggregatesModel.OrderAggregates;
using FluentAssertions;
using Xunit;

namespace CleanArch.UnitTests.AggregatesModel.OrderAggregates;

/// <summary>
/// Customer Entity Tests
/// </summary>
public class CustomerTests
{
    [Fact]
    public void Should_Instantiate_Customer_With_FirstName()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);
    
        // When
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.FirstName.Should().Be(firstName);
    }

    [Fact]
    public void Should_Instantiate_Customer_With_LastName()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);
    
        // When
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.LastName.Should().Be(lastName);
    }

    [Fact]
    public void Should_Instantiate_Customer_With_Shipping_Street()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);
    
        // When
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.ShippingAddress.Street.Should().Be(street);
    }

    [Fact]
    public void Should_Instantiate_Customer_With_Shipping_State()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);
    
        // When
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.ShippingAddress.State.Should().Be(state);
    }

    [Fact]
    public void Should_Instantiate_Customer_With_Shipping_City()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);
    
        // When
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.ShippingAddress.City.Should().Be(city);
    }

    [Fact]
    public void Should_Instantiate_Customer_With_Shipping_ZipCode()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);
    
        // When
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.ShippingAddress.ZipCode.Should().Be(zipCode);
    }

    [Fact]
    public void Should_Instantiate_Customer_With_Generated_Id()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);
    
        // When
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_Validate_Customer_FirstName_Must_Not_Be_Empty()
    {
        // Given
        Faker faker = new("en");
        var firstName = string.Empty;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);

        var addressValidator = new AddressValidator();
        var customerValidator = new CustomerValidator(addressValidator);
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // When
        var validationResult = customerValidator.Validate(customer);

        // Then
        validationResult.Errors.Should().Contain(error => 
            error.ErrorMessage == "'First Name' must not be empty.");
    }

    [Fact]
    public void Should_Validate_Customer_LastName_Must_Not_Be_Empty()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = string.Empty;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);

        var addressValidator = new AddressValidator();
        var customerValidator = new CustomerValidator(addressValidator);
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // When
        var validationResult = customerValidator.Validate(customer);

        // Then
        validationResult.Errors.Should().Contain(error => 
            error.ErrorMessage == "'Last Name' must not be empty.");
    }

    [Fact]
    public void Should_Validate_Customer_ShippingAddressStreet_Must_Not_Be_Empty()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = string.Empty;
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);

        var addressValidator = new AddressValidator();
        var customerValidator = new CustomerValidator(addressValidator);
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // When
        var validationResult = customerValidator.Validate(customer);

        // Then
        validationResult.Errors.Should().Contain(error => 
            error.ErrorMessage == "'Street' must not be empty.");
    }

    [Fact]
    public void Should_Validate_Customer_ShippingAddressCity_Must_Not_Be_Empty()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = string.Empty;
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);

        var addressValidator = new AddressValidator();
        var customerValidator = new CustomerValidator(addressValidator);
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // When
        var validationResult = customerValidator.Validate(customer);

        // Then
        validationResult.Errors.Should().Contain(error => 
            error.ErrorMessage == "'City' must not be empty.");
    }

    [Fact]
    public void Should_Validate_Customer_ShippingAddressState_Must_Not_Be_Empty()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = string.Empty;
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);

        var addressValidator = new AddressValidator();
        var customerValidator = new CustomerValidator(addressValidator);
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // When
        var validationResult = customerValidator.Validate(customer);

        // Then
        validationResult.Errors.Should().Contain(error => 
            error.ErrorMessage == "'State' must not be empty.");
    }

    [Fact]
    public void Should_Validate_Customer_ShippingAddressZipCode_Must_Not_Be_Empty()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.ZipCode();
        var zipCode = string.Empty;
        Address shippingAddress = new(street, city, state, zipCode);

        var addressValidator = new AddressValidator();
        var customerValidator = new CustomerValidator(addressValidator);
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // When
        var validationResult = customerValidator.Validate(customer);

        // Then
        validationResult.Errors.Should().Contain(error => 
            error.ErrorMessage == "'Zip Code' must not be empty.");
    }
}
