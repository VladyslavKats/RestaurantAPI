using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL;
using Restaurant.BLL.Interfaces;
using Restaurant.BLL.Models;
using Restaurant.PL.Helpers;
using Restaurant.PL.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public CategoriesController(IProductService productService , IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetAll()
        {
            var categoriesFromDb = await productService.GetAllCategoriesAsync();
           
            var categories = mapper.Map<IEnumerable<CategoryViewModel>>(categoriesFromDb);
            
            return Ok(categories);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CategoryViewModel>> Get(int id)
        {
            try
            {
                var categoryFromService = await productService.GetCategoryByIdAsync(id);

                var category = mapper.Map<CategoryViewModel>(categoryFromService);
                return Ok(category);
            }catch(RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/details")]
        public async Task<ActionResult<CategoryDetail>> GetWithDetails(int id)
        {
            try
            {
                var categoryFromService = await productService.GetCategoryByIdWithDetailsAsync(id);

                var category = mapper.Map<CategoryDetail>(categoryFromService);
                foreach (var product in category.Products)
                {
                    product.ImageUrl = UrlHelper.GetUrlForImage(HttpContext , product.Name);
                }
                return Ok(category);
            }
            catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("details")]
        public async Task<ActionResult<IEnumerable<CategoryDetail>>> GetAllWithDetails()
        {
            var categoriesFromDb = await productService.GetAllCategoriesWithDetailsAsync();

            var categories = mapper.Map<IEnumerable<CategoryDetail>>(categoriesFromDb);
            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    product.ImageUrl = UrlHelper.GetUrlForImage(HttpContext, product.Name);
                }
                
            }
            return Ok(categories);
        }

        [HttpPost]
       public async Task<ActionResult<CategoryViewModel>> Add([FromBody]CategoryCreateModel model)
        {
            var category = mapper.Map<CategoryDto>(model);
            try
            {
                var categoryCreated = await productService.AddCategoryAsync(category);
                return Ok(mapper.Map<CategoryViewModel>(categoryCreated));
            }catch(RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody]CategoryViewModel model)
        {
            var category = mapper.Map<CategoryDto>(model);
            try
            {
                await productService.UpdateCategoryAsync(category);
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
                await productService.DeleteCategoryAsync(id);
                return Ok();
            }
            catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
