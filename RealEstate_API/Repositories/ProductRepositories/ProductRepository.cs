using Dapper;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.ProductDtos;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,CategoryName,ProductImage,ProductAddress,ProductType,DealOfTheDay from Product inner join Category on Product.ProductCategory=Category.CategoryID ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,ProductCategory,CategoryName,Date From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Where ProductType='Kiralık' Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
		{
			string query = "Update Product Set DealOfTheDay=0 where ProductID=@productID";
			var parameters = new DynamicParameters();
			parameters.Add("@productID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
		{
			string query = "Update Product Set DealOfTheDay=1 where ProductID=@productID";
			var parameters = new DynamicParameters();
			parameters.Add("@productID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
