using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly DevReviewsDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductReviewsController(DevReviewsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int productId, int id)
        {
            //inputModel = para entrada
            //viewModel = para saída

            var productReview = await _dbContext.DbProductsReview
                .SingleOrDefaultAsync(p => p.Id.Equals(id));

            if (productReview == null) return NotFound();

            var productDetails =  _mapper.Map<ProductReviewDetailsViewModel>(productReview);

            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(int productId, AddProductReviewInputModel model)
        {
            var productReview = new ProductReview(model.Author, model.Racting, model.Comments.Trim(), productId);

            await _dbContext.DbProductsReview.AddAsync(productReview);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = productReview.Id, productId = productId }, model);
        }
    }
}
