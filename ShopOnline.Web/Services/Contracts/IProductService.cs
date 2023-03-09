using ShopOnline.Data.DTO;

namespace ShopOnline.Web.Services.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetItems();
}
