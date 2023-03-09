using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.DTO;
using ShopOnline.Data.Repositories.Contracts;
using ShopOnline.Api.Extensions;

namespace ShopOnline.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
    {
        try
        {
            var products = await _productRepository.GetItems();


            if (products != null)
            {
                var productDtos = products.ConvertToDto();

                return Ok(productDtos);
            }
            else
            {
                return NotFound();
            }

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                            "Error retrieving data from the database");

        }
    }
}
