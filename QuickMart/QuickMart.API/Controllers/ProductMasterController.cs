using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickMart.Core.Models;
using QuickMart.Core.Service;

namespace QuickMart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMasterController : ControllerBase
    {
        IProductMasterService _productMasterService;
        public ProductMasterController(IProductMasterService productMasterService)
        {
            _productMasterService = productMasterService;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productMasterService.GetProductList();
                if (products == null) return NotFound();
                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("SaveProducts")]
        public async Task<IActionResult> SaveProducts([FromForm] ProductMaster productMaster)
        {
            try
            {

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("GetProductById")]
        public async Task<IActionResult> GetProductById(int productID)
        {
            try
            {
                var products = _productMasterService.GetProductDetailsById(productID);
                if (products == null) return NotFound();
                else
                   
                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int productID)
        {
            try
            {
                var model = _productMasterService.DeleteProduct(productID);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
