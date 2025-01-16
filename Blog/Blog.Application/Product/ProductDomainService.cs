using Blog.Domain.ProductAgg.Repository;
using Blog.Domain.ProductAgg.Services;

namespace Blog.Application.Product
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _repository;

        public ProductDomainService(IProductRepository repository)
        {
            _repository = repository;
        }

        public bool SlugIsExist(string slug)
        {
            return _repository.Exists(r => r.Slug == slug);
        }
    }
}
