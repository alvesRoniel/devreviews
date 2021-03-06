using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            var productViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(productViewModel);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetDetailsByIdAsync(id);

            if (product == null) return NotFound();

            //var productDetails =  _mapper.Map<ProductDetailsViewModel>(product);

            return Ok(product);
        }

        /// <summary>
        /// Cadastro de Produtos
        /// </summary>
        /// <param name="model">Objeto com os dados de cadastro de Produto</param>
        /// <returns>Objeto recém criadno</returns>
        /// <remarks>Requisição
        /// {
        ///     "title": "Um chinelo top",
        ///     "description": "Um chinelo de Marca",
        ///     "price": 100
        /// }
        /// </remarks>
        ///<response code="201">Sucesso</response>
        ///<response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(AddProductInputModel model)
        {
            var product = new Product(model.Title, model.Description, model.Price);

            await _productRepository.AddAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, UpdateProductInputModel model)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null) return NotFound();

            product.Upadate(model.Description, model.Price);

            await _productRepository.UpdateAsync(product);

            return NoContent();
        }

    }
}
