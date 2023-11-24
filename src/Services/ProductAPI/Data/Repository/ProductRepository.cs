namespace Mango.Services.ProductAPI.Data.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public ProductRepository(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ProductModel> CreateProduct(CreateProductModel data)
		{
			Product? product = _mapper.Map<Product>(data);
			product.ProductId = Guid.NewGuid();

			_context.Products.Add(product);
			int result = await _context.SaveChangesAsync();

			return result > 0 ? _mapper.Map<ProductModel>(product) : new ProductModel();
		}

		public async Task<bool> DeleteProduct(Guid productId)
		{
			try
			{
				Product? product = await _context.Products.FirstOrDefaultAsync(a => a.ProductId == productId);
				if (product == null) return false;

				_context.Products.Remove(product);

				int result = await _context.SaveChangesAsync();
				return result > 0;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public async Task<ProductModel> GetProductById(Guid productId)
		{
			Product? product = await _context.Products.FirstOrDefaultAsync(a => a.ProductId == productId);
			return _mapper.Map<ProductModel>(product);
		}

		public async Task<IEnumerable<ProductModel>> GetProducts()
		{
			List<Product>? productList = await _context.Products.ToListAsync();
			return _mapper.Map<List<ProductModel>>(productList);
		}

		public async Task<ProductModel> UpdateProduct(UpdateProductModel data)
		{
			Product? product = await _context.Products.FirstOrDefaultAsync(a => a.ProductId == data.ProductId);
			if (product != null)
			{
				product = _mapper.Map(data, product);
				
				_context.Products.Update(product);
				int result = await _context.SaveChangesAsync();

				return result > 0 ? _mapper.Map<ProductModel>(data) : new ProductModel();
			}

			return new ProductModel();
		}
	}
}
