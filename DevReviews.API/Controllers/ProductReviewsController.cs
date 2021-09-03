using DevReviews.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/productReviews")]
    public class ProductReviewsController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult GetById(int productId, int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Adicionar(int productId, AddProductReviewInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1, productId = 2 }, model);
        }
    }
}
