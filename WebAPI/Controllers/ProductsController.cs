using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallwithdetails")]
        public IActionResult GetAllWithDetails()
        {
            var result = _productService.GetAllWithDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallwithdetailsbycategoryname")]
        public IActionResult GetAllWithDetailsByCategoryName(string categoryName)
        {
            var result = _productService.GEtAllWithDetailsByCategoryName(categoryName);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallwithdetailsbybrandname")]
        public IActionResult GetAllWithDetailsByBrandName(string brandName)
        {
            var result = _productService.GetAllWithDetailsByBrandName(brandName);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallwithdetailsbyprice")]
        public IActionResult GetAllWithDetailsByPrice(decimal begin, decimal end)
        {
            var result = _productService.GetAllWithDetailsByPrice(begin, end);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallwithdetailsbysearchvalue")]
        public IActionResult GetAllWithDetailsByProductName(string value)
        {
            var result = _productService.GetAllWithDetailsBySearchValue(value);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getwithdetailsbyid")]
        public IActionResult GetWithDetailsById(int productId)
        {
            var result = _productService.GetProductWithDetailsById(productId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbycategory")]
        public IActionResult GetAllByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategory(categoryId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbybrand")]
        public IActionResult GetAllByBrand(int brandId)
        {
            var result = _productService.GetAllByBrand(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
