using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Restaurant.BLL;
using Restaurant.BLL.Interfaces;
using Restaurant.BLL.Models;
using Restaurant.PL.Helpers;
using Restaurant.PL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
       

        public ProductsController(IProductService productService , IMapper mapper , IHost hostingEnvironment)
        {
            this.productService = productService;
            this.mapper = mapper;
          
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAll()
        {
            var productsFromService = await productService.GetAllProductsAsync();

            var products = mapper.Map<IEnumerable<ProductViewModel>>(productsFromService);
            foreach (var product in products)
            {
                product.ImageUrl = UrlHelper.GetUrlForImage(HttpContext , product.Name);
            }
            return Ok(products);
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> Get(int id)
        {
            try
            {
                
                var productFromService = await productService.GetProductByIdAsync(id);
                var product = mapper.Map<ProductViewModel>(productFromService);
                product.ImageUrl = UrlHelper.GetUrlForImage(HttpContext , product.Name);
                return product;
            }catch(RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductsByCategory(int categoryId)
        {
            try
            {
                var productsFromService = await productService.GetProductsByCategoryAsync(categoryId);

                var products = mapper.Map<IEnumerable<ProductViewModel>>(productsFromService);
                foreach (var product in products)
                {
                    product.ImageUrl = UrlHelper.GetUrlForImage(HttpContext, product.Name);
                }
                return Ok(products);
            }catch(RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Add([FromBody]ProductCreateModel model)
        {
            try
            {
                var productToAdd = mapper.Map<ProductDto>(model);

                var productCreated = await productService.AddProductAsync(productToAdd);

                 var product = mapper.Map<ProductViewModel>(productCreated);

                product.ImageUrl = UrlHelper.GetUrlForImage(HttpContext , product.Name);

                return Ok(product);
            }catch(RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("details")]
        public async Task<ActionResult<IEnumerable<ProductDetailModel>>> GetAllWithDetails()
        {
            var productsFromService = await productService.GetAllProductsAsync();

            var products = mapper.Map<IEnumerable<ProductDetailModel>>(productsFromService);
            foreach (var product in products)
            {
                product.ImageUrl = UrlHelper.GetUrlForImage(HttpContext, product.Name);
            }
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}/details")]
        public async Task<ActionResult<ProductDetailModel>> GetWithDetails(int id)
        {
            try
            {

                var productFromService = await productService.GetProductByIdAsync(id);
                var product = mapper.Map<ProductDetailModel>(productFromService);
                product.ImageUrl = UrlHelper.GetUrlForImage(HttpContext, product.Name);
                return product;
            }
            catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody]ProductViewModel model)
        {
            var product = mapper.Map<ProductDto>(model);
            try
            {
                await productService.UpdateProductAsync(product);
                return Ok();
            }
            catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await productService.DeleteProductAsync(id);
                return Ok();
            }catch(RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{productId}/ingredient/{ingredientId}")]
        public async Task<ActionResult> DeleteIngredient(int productId , int ingredientId)
        {
            try
            {
                await productService.DeleteIngredientFromProductAsync(productId , ingredientId);
                return Ok();
            }
            catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
