using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/productReviews")]
    public class ProductReviewsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductReviewsController(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int productId, int id)
        {
            //inputModel = para entrada
            //viewModel = para saída

            var productReview = await _productRepository.GetReviewByIdAsync(id);

            if (productReview == null) return NotFound();

            var productDetails =  _mapper.Map<ProductReviewDetailsViewModel>(productReview);

            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(int productId, AddProductReviewInputModel model)
        {
            var productReview = new ProductReview(model.Author, model.Racting, model.Comments.Trim(), productId);

            await _productRepository.AddReviewAsync(productReview);

            return CreatedAtAction(nameof(GetById), new { id = productReview.Id, productId = productId }, model);
        }
    }
}
