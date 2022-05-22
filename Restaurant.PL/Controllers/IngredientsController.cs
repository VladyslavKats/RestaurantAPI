using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL;
using Restaurant.BLL.Interfaces;
using Restaurant.BLL.Models;
using Restaurant.PL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public IngredientsController(IProductService productService , IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientViewModel>>> GetAll()
        {
            var ingredientsFromService = await productService.GetAllIngredients();
            
            var ingredients =  mapper.Map<IEnumerable<IngredientViewModel>>(ingredientsFromService);

            return Ok(ingredients);

        }

        [HttpPost]
        public async Task<ActionResult<IngredientViewModel>> Add([FromBody]IngredientCreateModel model)
        {
            try
            {
                var ingredient = mapper.Map<IngredientDto>(model);
                var ingredientAdded = await productService.AddIngredientAsync(ingredient);
                return Ok(mapper.Map<IngredientViewModel>(ingredientAdded));
            }catch(RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await productService.DeleteIngredientAsync(id);
                return Ok();
            }
            catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] IngredientViewModel model)
        {
            var ingredient = mapper.Map<IngredientDto>(model);
            try
            {
                await productService.UpdateIngredientAsync(ingredient);
                return Ok();
            }
            catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
