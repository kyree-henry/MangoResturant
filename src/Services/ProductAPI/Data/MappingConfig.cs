namespace Mango.Services.ProductAPI.Data
{
	public class MappingConfig : Profile
    {
        public MappingConfig()
        {
			CreateMap<Product, ProductModel>().ReverseMap();
			CreateMap<CreateProductModel, Product>().ReverseMap();
			CreateMap<UpdateProductModel, Product>().ReverseMap();
		}
    }
}
