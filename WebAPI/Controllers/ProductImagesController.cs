using Business.Abstract;
using Core.Utilities.UploadFiles;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        IProductImageService _productImageService;

        IHostEnvironment _hostEnvironment;

        public ProductImagesController(IProductImageService productImageService, IHostEnvironment hostEnvironment)
        {
            _productImageService = productImageService;

            _hostEnvironment = hostEnvironment;
        }

        [HttpGet("getallbyproduct")]
        public IActionResult GetAllByProduct(int productId)
        {
            var result = _productImageService.GetAllByProduct(productId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getfirstimagebyproduct")]
        public IActionResult GetFirstImageByProduct(int productId)
        {
            var result = _productImageService.GetFirstImageByProduct(productId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productImageService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(IFormFile formFile, int productId)
        {
            var imagePath = FileManager.Create(_hostEnvironment, formFile);

            var result = _productImageService.Add(new ProductImage
            {
                ProductId = productId,
                ImagePath = imagePath
            });

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ProductImage productImage)
        {
            var result = _productImageService.Delete(productImage);

            if (result.Success)
            {
                FileManager.Delete(_hostEnvironment, productImage.ImagePath);

                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
