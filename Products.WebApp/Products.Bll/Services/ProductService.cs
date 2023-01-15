using AutoMapper;
using Products.Bll.Interfaces;
using Products.Common.Dtos.Products;
using Products.Dal.Interfaces;
using Products.Domain;

namespace Products.Bll.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var records = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(records);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var result = _mapper.Map<ProductDto>(product);
            return result;
        }

        public async Task CreateProductAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.AddAsync(product);
        }
    }
}
