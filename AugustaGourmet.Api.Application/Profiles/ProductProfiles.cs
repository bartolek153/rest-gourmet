using AugustaGourmet.Api.Application.Features.ProductCategories;
using AugustaGourmet.Api.Application.Features.ProductCategories.CreateProductCategory;
using AugustaGourmet.Api.Application.Features.ProductCategories.UpdateProductCategory;
using AugustaGourmet.Api.Application.Features.ProductFamilies;
using AugustaGourmet.Api.Application.Features.ProductFamilies.CreateProductFamily;
using AugustaGourmet.Api.Application.Features.ProductFamilies.UpdateProductFamily;
using AugustaGourmet.Api.Application.Features.ProductGroups;
using AugustaGourmet.Api.Application.Features.ProductGroups.CreateProductGroup;
using AugustaGourmet.Api.Application.Features.ProductGroups.UpdateProductGroup;
using AugustaGourmet.Api.Application.Features.Products.CreateProduct;
using AugustaGourmet.Api.Application.Features.Products.GetAllProducts;
using AugustaGourmet.Api.Application.Features.Products.UpdateProduct;
using AugustaGourmet.Api.Domain.Entities.Products;

using AutoMapper;

namespace AugustaGourmet.Api.Application.Profiles;

public class ProductProfiles : Profile
{
    public ProductProfiles()
    {
        // Product Category
        CreateMap<ProductCategory, ProductCategoryDto>();
        CreateMap<CreateProductCategoryCommand, ProductCategory>();
        CreateMap<UpdateProductCategoryCommand, ProductCategory>();

        // Product Family
        CreateMap<ProductFamily, ProductFamilyDto>();
        CreateMap<CreateProductFamilyCommand, ProductFamily>();
        CreateMap<UpdateProductFamilyCommand, ProductFamily>();

        // Product Group
        CreateMap<ProductGroup, ProductGroupDto>();
        CreateMap<CreateProductGroupCommand, ProductGroup>();
        CreateMap<UpdateProductGroupCommand, ProductGroup>();

        // Product
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}