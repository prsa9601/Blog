using Common.Domain.Repository;

namespace Blog.Domain.ProductAgg.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<bool> DeleteProduct(Product product);
        Task<bool> DeleteSpecification(ProductSpecification specification);
        Task<bool> DeleteImage(ProductImage image);
        Task<bool> DeleteInventory(ProductInventory inventory);
        
        Task<InventoryResult?> GetInventoryById(long id);
        

        public class InventoryResult
        {
            public long Id { get; set; }
            public long SellerId { get; set; }
            public long ProductId { get; set; }
            public int Count { get; set; }
            public int Price { get; set; }
        }
    }
}
