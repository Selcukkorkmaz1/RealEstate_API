using RealEstate_API.Dtos.ProductDtos;

namespace RealEstate_API.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
		Task ProductDealOfTheDayStatusChangeToTrue(int id);
		Task ProductDealOfTheDayStatusChangeToFalse(int id);
	}
}
