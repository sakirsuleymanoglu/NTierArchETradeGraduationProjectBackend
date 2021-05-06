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

        private readonly IHostEnvironment _hostEnvironment;

        public ProductImagesController(IProductImageService productImageService, IHostEnvironment hostEnvironment)
        {
            _productImageService = productImageService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpPost("add")]
        public IActionResult Add(IFormFile formFile, [FromQuery] int productId)
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
    }
}
