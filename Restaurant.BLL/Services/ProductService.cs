using AutoMapper;
using Restaurant.BLL.Interfaces;
using Restaurant.BLL.Models;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IRestaurantUW context;
        private readonly IMapper mapper;

        public ProductService(IRestaurantUW context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        private void validateCategory(CategoryDto category)
        {
            if (category == null || string.IsNullOrEmpty(category.Name))
                throw new RestaurantException("incorrect data");
        }

        private void validateIngredient(IngredientDto ingredient)
        {
            if (ingredient == null || string.IsNullOrEmpty(ingredient.Name))
                throw new RestaurantException("incorrect data");
        }

        public async Task<CategoryDto> AddCategoryAsync(CategoryDto category)
        {

            validateCategory(category);
            var item = mapper.Map<Category>(category);
            await context.Categories.AddAsync(item);
            await context.SaveAsync();
            return mapper.Map<CategoryDto>(item);
        }

        public async Task<IngredientDto> AddIngredientAsync(IngredientDto ingredient)
        {
            validateIngredient(ingredient);
            var item = mapper.Map<Ingredient>(ingredient);
            await context.Ingredients.AddAsync(item);
            await context.SaveAsync();
            return mapper.Map<IngredientDto>(item);
        }

        public async Task<ProductDto> AddProductAsync(ProductDto product)
        {
            validateProduct(product);
            var item = mapper.Map<Product>(product);
            await context.Products.AddAsync(item);
            await context.SaveAsync();
            var productReturn = mapper.Map<ProductDto>(item);
            return productReturn;
        }

        private void validateProduct(ProductDto product)
        {
            if (product == null || product.Weight <= 0 || product.Cost <= 0 || string.IsNullOrEmpty(product.Name))
                throw new RestaurantException("incorrect data");
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new RestaurantException("incorrect data");
            await context.Categories.DeleteAsync(new Category {Id = categoryId }); 
        }

        public async Task DeleteIngredientAsync(int ingredientId)
        {
            if (ingredientId <= 0)
                throw new RestaurantException("incorrect data");
            await context.Ingredients.DeleteAsync(new Ingredient { Id = ingredientId });
            await context.SaveAsync();
        }

       

        public async Task DeleteProductAsync(int productId)
        {
            if (productId <= 0)
                throw new RestaurantException("incorrect data");
            await context.Products.DeleteAsync(new Product { Id = productId });
            await context.SaveAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await context.Categories.GetAllAsync();
            return mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesWithDetailsAsync()
        {
            var categories = await context.Categories.GetAllWithDetailsAsync();
            return mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<IEnumerable<IngredientDto>> GetAllIngredients()
        {
            var ingredients = await context.Ingredients.GetAllAsync();
            return mapper.Map<IEnumerable<IngredientDto>>(ingredients);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            //
            var products = await context.Products.GetAllWithDetailsAsync();
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var product = await context.Products.GetByIdWithDetailsAsync(productId);
            return mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId)
        {
            var allProducts = await context.Products.GetAllAsync();
            var products = allProducts.Where(p => p.CategoryId == categoryId).ToList();
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task UpdateCategoryAsync(CategoryDto category)
        {
            validateCategory(category);
            var item = mapper.Map<Category>(category);
            await context.Categories.UpdateAsync(item);
            await context.SaveAsync();
        }

        public async Task UpdateIngredientAsync(IngredientDto ingredient)
        {
            validateIngredient(ingredient);
            var item = mapper.Map<Ingredient>(ingredient);
            await context.Ingredients.UpdateAsync(item);
            await context.SaveAsync();
        }

        public async Task UpdateProductAsync(ProductDto product)
        {
            validateProduct(product);
            var item = mapper.Map<Product>(product);
            await context.Products.UpdateAsync(item);
            await context.SaveAsync();
        }

        public async Task DeleteIngredientFromProductAsync(int productId, int ingredientId)
        {
            var product = await context.Products.GetByIdWithDetailsAsync(productId);
            var igredient = await context.Ingredients.GetByIdAsync(ingredientId);
            if (product != null && igredient != null)
            {
                product.Ingredients.Remove(igredient);
                await context.SaveAsync();
            }
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new RestaurantException("id must be more than 0");
            var categoryFromDb = await context.Categories.GetByIdAsync(categoryId);
            var category = mapper.Map<CategoryDto>(categoryFromDb);
            return category;
        }

        public async Task<CategoryDto> GetCategoryByIdWithDetailsAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new RestaurantException("id must be more than 0");
            var categoryFromDb = await context.Categories.GetByIdWithDetailsAsync(categoryId);
            var category = mapper.Map<CategoryDto>(categoryFromDb);
            return category;
        }
    }
}
