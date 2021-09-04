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
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DevReviewsDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductsController(DevReviewsDbContext DbContext, IMapper mapper)
        {
            _dbContext = DbContext;
            _mapper = mapper;
        }

        // GET para api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _dbContext.DbProducts;
            var productViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(productViewModel);
        }

        // GET para api/products/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _dbContext.DbProducts
                .Include(p => p.ProductReviews)
                .SingleOrDefaultAsync(p => p.Id.Equals(id));


            if (product == null) return NotFound();

            var productDetails =  _mapper.Map<ProductDetailsViewModel>(product);

            return Ok(productDetails);
        }

        // POST para api/products
        [HttpPost]
        public async Task<IActionResult> Post(AddProductInputModel model)
        {
            //  Se tiver erros de validação, retornar BadRequest()
            var product = new Product(model.Title, model.Description, model.Price);

            await _dbContext.DbProducts.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, model);
        }

        // PUT para api/products/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, UpdateProductInputModel model)
        {
            // Se tiver erros de validação, retornar BadRequest()
            // Se não existir produto com o id especificado, retornar NotFound()
            if (model.Description.Length > 50) return BadRequest();

            var product = await _dbContext.DbProducts.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (product == null) return NotFound();

            product.Upadate(model.Description, model.Price);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
