using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;

using Moq;

namespace AugustaGourmet.Api.Application.UnitTests.Mocks;

internal class MockProductCategoryRepository
{
    public static Mock<IProductCategoryRepository> GetMockProductCategoryRepository()
    {
        var categories = new List<ProductCategory>
        {
            new ProductCategory
            {
                Id = 1,
                Description = "AAA",
                CompanyId = 1,
                EXIBIR_CARDAPIO = 0,
            },
            new ProductCategory
            {
                Id = 2,
                Description = "BBB",
                CompanyId = 1,
                EXIBIR_CARDAPIO = 0,
            },
            new ProductCategory
            {
                Id = 3,
                Description = "CCC",
                CompanyId = 2,
                EXIBIR_CARDAPIO = 0,
            }
        };

        var mockRepo = new Mock<IProductCategoryRepository>();

        mockRepo.Setup(r => r.GetAllAsync())
            .ReturnsAsync(categories);

        //mockRepo.Setup(r => r.CreateAsync(It.IsAny<ProductCategory>()))
        //    .Returns((ProductCategory category) =>
        //    {
        //        categories.Add(category);
        //        return Task.CompletedTask;
        //    });

        return mockRepo;
    }
}