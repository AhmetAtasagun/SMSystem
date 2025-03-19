using AutoMapper;
using SMSystem.Application.Features.Commands.Categories.CreateCategory;
using SMSystem.Application.Features.Commands.Categories.UpdateCategory;
using SMSystem.Application.Features.Commands.Inventories.CreateInventory;
using SMSystem.Application.Features.Commands.Inventories.UpdateInventory;
using SMSystem.Application.Features.Commands.Products.CreateProduct;
using SMSystem.Application.Features.Commands.Products.UpdateProduct;
using SMSystem.Application.Features.Commands.Sales.CreateSale;
using SMSystem.Application.Features.Commands.Sales.UpdateSale;
using SMSystem.Application.Features.Commands.Users.CreateUser;
using SMSystem.Application.Features.Commands.Users.UpdateUser;
using SMSystem.Application.Mapping.Localizations;
using SMSystem.Domain.Dtos;
using SMSystem.Domain.Entities;

namespace SMSystem.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<CreateUserCommandRequest, User>().ReverseMap();
            CreateMap<UpdateUserCommandRequest, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            // Product mappings
            CreateMap<CreateProductCommandRequest, Product>().ReverseMap();
            CreateMap<UpdateProductCommandRequest, Product>().ReverseMap();
            CreateMap<Product, ProductDto>()
                .ForMember(
                    destination => destination.CategoryName,
                    opt =>
                    {
                        opt.PreCondition(res => res.Category != null);
                        opt.MapFrom(res => res.Category.Name);
                    })
                .AfterMap<ProductLocalization>()
                .ReverseMap();
            CreateMap<Product, ProductWithInventoryDto>()
                .ForMember(
                    destination => destination.CategoryName,
                    opt =>
                    {
                        opt.PreCondition(res => res.Category != null);
                        opt.MapFrom(res => res.Category.Name);
                    })
                .AfterMap<ProductLocalization>()
                //.ForMember(
                //    destination => destination.Inventories,
                //    opt => opt.MapFrom(src => src.Inventories))
                .ReverseMap();

            // Category mappings
            CreateMap<CreateCategoryCommandRequest, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommandRequest, Category>().ReverseMap();
            CreateMap<Category, CategoryDto>()
                .ForMember(
                    destination => destination.ParentName,
                    opt =>
                    {
                        opt.PreCondition(res => res.Parent != null);
                        opt.MapFrom(res => res.Parent.Name);
                    })
                .AfterMap<CategoryLocalization>()
                .ReverseMap();

            // Inventory mappings
            CreateMap<CreateInventoryCommandRequest, Inventory>().ReverseMap();
            CreateMap<UpdateInventoryCommandRequest, Inventory>().ReverseMap();
            CreateMap<Inventory, InventoryDto>()
                .AfterMap<InventoryProcessLocalization>()
                .ReverseMap();

            // Sale mappings
            CreateMap<CreateSaleCommandRequest, Sale>().ReverseMap();
            CreateMap<UpdateSaleCommandRequest, Sale>().ReverseMap();
            CreateMap<Sale, SaleDto>()
                .ForMember(
                    destination => destination.ProductName,
                    opt =>
                    {
                        opt.PreCondition(res => res.Product != null);
                        opt.MapFrom(res => res.Product.Name);
                    })
                .ForMember(
                    destination => destination.ProductPrice,
                    opt =>
                    {
                        opt.PreCondition(res => res.Product != null);
                        opt.MapFrom(res => res.Product.Price);
                    })
                .ForMember(
                    destination => destination.StaffName,
                    opt =>
                    {
                        opt.PreCondition(res => res.Staff != null);
                        opt.MapFrom(res => res.Staff.FullName);
                    })
                .ReverseMap();

        }
    }
}