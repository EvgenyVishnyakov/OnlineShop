using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApi.Service;

namespace OnlineShopWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetProductByProductId")]
    public async Task<IActionResult> IndexAsync(Guid productId)
    {
        var product = await _productService.GetProductAsync(productId);
        if (product != null)
            return Ok(product);
        else
            return Ok($"Продукта {productId} не существует");
    }

    [HttpGet("GatProductByName")]
    public async Task<IActionResult> FindNameAsync(string name)
    {
        var product = await _productService.GetAsync(name);
        if (product != null)
            return Ok(product);
        else
            return Ok($"Продукта {name} не существует");
    }
}
