using Microsoft.AspNetCore.Mvc;
using ShopOnline.Data.Repositories.Contracts;
using ShopOnline.Data.DTO;
using ShopOnline.Data.Extensions;

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

            return NotFound();

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                            "Error retrieving data from the database");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetItem(int id)
    {
        try
        {
            var product = await _productRepository.GetItem(id);

            if (product != null)
            {
                var productDto = product.ConvertToDto();

                return Ok(productDto);
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");

        }
    }
}
