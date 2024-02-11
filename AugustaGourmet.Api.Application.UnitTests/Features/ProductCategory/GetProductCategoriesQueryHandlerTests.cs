using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Products;
using AugustaGourmet.Api.Application.Features.ProductCategories.GetProductCategories;
using AugustaGourmet.Api.Application.Profiles;
using AugustaGourmet.Api.Application.UnitTests.Mocks;

using AutoMapper;

using Moq;

using Shouldly;

namespace AugustaGourmet.Api.Application.UnitTests.Features.ProductCategory
{
    public class GetProductCategoriesQueryHandlerTests
    {
        private readonly Mock<IProductCategoryRepository> _mockRepo;
        private readonly IMapper _mapper;

        public GetProductCategoriesQueryHandlerTests()
        {
            _mockRepo = MockProductCategoryRepository.GetMockProductCategoryRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetProductCategoryListTest()
        {
            var handler = new GetProductCategoriesQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetProductCategoriesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ProductCategoryDto>>();
            result.Count.ShouldBe(3);
        }
    }
}