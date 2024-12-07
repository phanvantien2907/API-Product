using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_API.Models;

namespace Product_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly WebMyPhamContext _context;

        public ProductController(WebMyPhamContext context)
        {
            this._context = context;
        }

        [HttpGet(Name = "GetAllProduct")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.TblProducts.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetAllProductsById(int id)
        {
            var product = await _context.TblProducts.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<IActionResult> CreateProduct(TblProduct product)
        {
            await _context.TblProducts.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }


        [HttpPut("{id}", Name = "UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int id, TblProduct product)
        {
            var existProduct = await _context.TblProducts.FindAsync(id);
            if (existProduct == null)
            {
                return NotFound();
            }
            existProduct.ProductName = product.ProductName;
            existProduct.Alias = product.Alias;
            existProduct.Price = product.Price;
            existProduct.PriceSale = product.PriceSale;
            existProduct.Images = product.Images;
            existProduct.Sku = product.Sku;
            existProduct.Status = product.Status;
            existProduct.MainIngredients = product.MainIngredients;
            existProduct.SuitableFor = product.SuitableFor;
            existProduct.Capacity = product.Capacity;
            existProduct.Quantity = product.Quantity;
            _context.TblProducts.Update(existProduct);
            await _context.SaveChangesAsync();
            return Ok(existProduct);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.TblProducts.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.TblProducts.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(product); 
        }

    }
}
