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
    public class BasketsController : ControllerBase
    {
        IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("getallwithdetailsbyuser")]
        public IActionResult GetAllWithDetailsByUser(int userId)
        {
            var result = _basketService.GetAllWithDetailsByUser(userId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Basket basket)
        {
            var result = _basketService.Add(basket);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Basket basket)
        {
            var result = _basketService.Delete(basket);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("gettotalprice")]
        public IActionResult GetTotalPrice(int userId)
        {
            var result = _basketService.GetTotalPrice(userId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("deletebasket")]
        public IActionResult DeleteBasket(int basketId)
        {
            var result = _basketService.DeleteBasket(basketId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
