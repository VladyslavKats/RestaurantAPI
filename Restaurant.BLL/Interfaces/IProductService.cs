using Restaurant.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Interfaces
{
    public  interface IProductService
    {
        Task<ProductDto> AddProductAsync( ProductDto product );

        Task DeleteProductAsync(int productId);

        Task UpdateProductAsync(ProductDto product);

        Task<ProductDto> GetProductByIdAsync(int productId);

        Task<IEnumerable<ProductDto>> GetAllProductsAsync();

        Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId);

        Task DeleteIngredientFromProductAsync(int productId, int ingredientId);

        


        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();

        Task UpdateCategoryAsync(CategoryDto category);

        Task<IEnumerable<CategoryDto>> GetAllCategoriesWithDetailsAsync();

        Task DeleteCategoryAsync(int categoryId);

        Task<CategoryDto> AddCategoryAsync(CategoryDto category);

        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);

        Task<CategoryDto> GetCategoryByIdWithDetailsAsync(int categoryId);




        Task<IngredientDto> AddIngredientAsync(IngredientDto ingredient );

        Task DeleteIngredientAsync(int ingredientId);

        Task UpdateIngredientAsync(IngredientDto ingredient);

        Task<IEnumerable<IngredientDto>> GetAllIngredients();


    }
}
