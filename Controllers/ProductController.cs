using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _product;
        public ProductController(IProductRepository product)
        {
            _product = product ??
                throw new ArgumentNullException(nameof(product));
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _product.GetProduct());
        }
        [HttpGet]
        [Route("GetDepartmentByID/{Id}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            return Ok(await _product.GetProductByID(productId));
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Post(product dep)
        {
            var result = await _product.InsertProduct(dep);
            if (result.productId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Put(product dep)
        {
            await _product.UpdateProduct(dep);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteProduct")]
        public JsonResult Delete(int productId)
        {
            _product.DeleteProduct(productId);
            return new JsonResult("Deleted Successfully");
        }
    }
}
