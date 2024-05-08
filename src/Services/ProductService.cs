using AutoMapper;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using BackendTeamwork.Enums;


namespace BackendTeamwork.Services
{
    public class ProductService : IProductService
    {

        private IProductRepository _productRepository;
        private DatabaseContext _databaseContext;
        private IStockService _stockService;
        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper, DatabaseContext databaseContext, IStockService stockService)
        {
            _productRepository = productRepository;
            _databaseContext = databaseContext;
            _mapper = mapper;
            _stockService = stockService;
        }


        public IEnumerable<ProductReadDto> FindMany(int limit, int offset, SortBy sortBy)
        {
            return _productRepository.FindMany(limit, offset, sortBy).Select(_mapper.Map<ProductReadDto>);
        }

        public async Task<ProductReadDto?> FindOne(Guid productId)
        {
            return _mapper.Map<ProductReadDto>(await _productRepository.FindOne(productId));
        }

        public async Task<ProductReadDto> CreateOne(ProductCreateDto newProduct)
        {
            using (var transaction = _databaseContext.Database.BeginTransaction())
            {
                try
                {
                    Product product = await _productRepository.CreateOne(_mapper.Map<Product>(newProduct));

                    IEnumerable<StockCreateDto> stocks = newProduct.Stocks.Select(_mapper.Map<StockCreateDto>);

                    foreach (StockCreateDto stock in stocks)
                    {
                        stock.ProductId = product.Id;
                        await _stockService.CreateOne(stock);
                    }

                    transaction.Commit();
                    return _mapper.Map<ProductReadDto>(product);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new Exception("Something went wrong");
                }
            }
        }

        public async Task<ProductReadDto?> UpdateOne(Guid productId, ProductUpdateDto updatedProduct)
        {
            Product? oldProduct = await _productRepository.FindOne(productId);
            if (oldProduct is null)
            {
                return null;
            }
            Product product = _mapper.Map<Product>(updatedProduct);
            product.Id = productId;
            return _mapper.Map<ProductReadDto>(await _productRepository.UpdateOne(product));
        }

        public async Task<ProductReadDto?> DeleteOne(Guid productId)
        {
            Product? targetProduct = await _productRepository.FindOne(productId);
            if (targetProduct is not null)
            {
                return _mapper.Map<ProductReadDto>(await _productRepository.DeleteOne(targetProduct));
            }
            return null;
        }

        public IEnumerable<ProductReadDto> Search(string searchTerm)
        {
            return _productRepository.Search(searchTerm).Select(_mapper.Map<ProductReadDto>);
        }
    }
}