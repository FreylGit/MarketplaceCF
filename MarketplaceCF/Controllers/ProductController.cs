using AutoMapper;
using MarketplaceCF.Data.Repositories.Interfaces;
using MarketplaceCF.Models;
using MarketplaceCF.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceCF.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        protected ResponseDto _response;
        public ProductController(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<object> Create([FromBody] ProductDto productDto)
        {
            try
            {
                var model = _mapper.Map<Product>(productDto);
                await _productRepository.CreateProductAsync(model);
                _response.Result = productDto;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<object> GetAll()
        {
            try
            {
                var products =  _productRepository.Products.AsAsyncEnumerable();
                _response.Result = products;

            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<object>GetProductById(int id)
        {
            try
            {

                var model = await _productRepository.GetProdutByIdAsync(id);
                _response.Result = model;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<object> UpdateProduct([FromBody] ProductDto productDto)
        {
            try
            {
                var model = _mapper.Map<Product>(productDto);
                _response.IsSuccess =  await _productRepository.UpdateProductAsync(model);
                _response.Result = model;
            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpGet]
        [Route("GetProductsByName/{name}")]
        public async Task<object> GetProductsByName(string name)
        {
            try
            {
                var products = await _productRepository.GetProductsByNameAsync(name.ToLower());
                _response.Result = products;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
