using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApi.Service;

namespace OnlineShopWebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ProductManagmentController : Controller
{
    private readonly ProductService _productService;

    public ProductManagmentController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetProducts")]
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProductsAsync();
        if (products.Count != 0)
            return Ok(products);
        else
            return BadRequest($"Ошибка в поиске списка продуктов");
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(Guid productId)
    {
        var result = await _productService.DeleteAsync(productId);
        if (result)
            return Ok($"Продукт удален");
        else
            return BadRequest($"Ошибка в удалении продукта {productId}");
    }
}
