using RealEstate_API.Dtos.ProductDetailDtos;
using RealEstate_API.Dtos.ProductDtos;

namespace RealEstate_API.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
		Task ProductDealOfTheDayStatusChangeToTrue(int id);
		Task ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync();
        Task CreateProduct(CreateProductDto createProductDto);

        Task<GetProductByProductIDDto> GetProductByProductID(int id);
        Task<GetProductDetailByIDDto> GetProductDetailByProductID(int id);

    }
}
