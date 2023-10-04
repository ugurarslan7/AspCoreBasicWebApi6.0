using AspCoreBasicWebApi6._0.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreBasicWebApi6._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly DatabaseContext _context;

        public ProductController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> Get()
        {
            return Ok(await _context.productEntities.ToListAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProductEntity>> Get(int id)
        {
            var products = await _context.productEntities.FirstOrDefaultAsync(p => p.Id == id);
            if (products == null)
                return BadRequest("Product not found !");
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProductEntity>>> AddProduct(ProductEntity product)
        {
            _context.productEntities.Add(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.productEntities.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ProductEntity>>> UpdateProduct(ProductEntity productEntity)
        {
            var product =await _context.productEntities.FirstOrDefaultAsync(p => p.Id == productEntity.Id);
            if (product == null)
                return BadRequest("Product not found !");
            product.Name = productEntity.Name;
            product.Price = productEntity.Price;
            await _context.SaveChangesAsync();
            return Ok(await _context.productEntities.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<ProductEntity>>> DeleteProduct(int id)
        {
            var product =await _context.productEntities.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return BadRequest("Product not found !");
            _context.productEntities.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.productEntities.ToListAsync());
        }
    }
}
