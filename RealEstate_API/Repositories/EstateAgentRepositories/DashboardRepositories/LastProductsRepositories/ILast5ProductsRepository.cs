using RealEstate_API.Dtos.ProductDtos;

namespace RealEstate_API.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public interface ILast5ProductsRepository
    {
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id);

    }
}
