# Application.UnitTests Project

This project contains the unit tests for the application layer.

## Running the tests

To run the tests, execute the following command:

```bash
dotnet test
```

## Naming conventions

The tests should be named using the following pattern:

```csharp
[Fact]
public void MethodName_Should_ExpectedResult_OnCondition()
{
    // Arrange: prepare the test data and the test environment

    // Act: execute the method under test

    // Assert: verify the method's behavior and the expected result
}
```

An example of a test name would be:

```csharp
public
void CreateProduct_Should_ReturnProduct_OnValidData()
{
    var product = new Product
    {
        Name = "Product Name",
        Description = "Product Description",
        Price = 10.0m
    };

    var result = _productService.CreateProduct(product);

    Assert.NotNull(result);
}
```
