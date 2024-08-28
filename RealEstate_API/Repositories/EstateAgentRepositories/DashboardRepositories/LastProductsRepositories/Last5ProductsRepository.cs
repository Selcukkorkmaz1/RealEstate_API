using Dapper;
using RealEstate_API.Dtos.ProductDtos;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public class Last5ProductsRepository : ILast5ProductsRepository
    {
        private readonly Context _context;
        public Last5ProductsRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id)
        {
            string query = "Select Top(5) ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,ProductCategory,CategoryName,Date From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Where EmployeID=@employe Order By ProductID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@employe", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
