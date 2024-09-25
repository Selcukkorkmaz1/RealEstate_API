using Dapper;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.ProductDetailDtos;
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

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "Select ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,ProductCategory,ProductImage,ProductType,ProductAddress,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeID=@employeeId and ProductStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "Select ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,ProductCategory,ProductImage,ProductType,ProductAddress,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeID=@employeeId and ProductStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }
        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (ProductTitle,ProductPrice,ProductCity,ProductDistrict,ProductImage,ProductAddress,ProductDescription,ProductType,DealOfTheDay,Date,ProductStatus,ProductCategory,EmployeID) values (@Title,@Price,@City,@District,@CoverImage,@Address,@Description,@Type,@DealOfTheDay,@AdvertisementDate,@ProductStatus,@ProductCategory,@EmployeeID)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createProductDto.ProductTitle);
            parameters.Add("@Price", createProductDto.ProductPrice);
            parameters.Add("@City", createProductDto.ProductCity);
            parameters.Add("@District", createProductDto.ProductDistrict);
            parameters.Add("@CoverImage", createProductDto.ProductImage);
            parameters.Add("@Address", createProductDto.ProductAddress);
            parameters.Add("@Description", createProductDto.ProductDescription);
            parameters.Add("@Type", createProductDto.ProductType);
            parameters.Add("@DealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@AdvertisementDate", createProductDto.Date);
            parameters.Add("@ProductStatus", createProductDto.ProductStatus);
            parameters.Add("@ProductCategory", createProductDto.ProductCategory);
            parameters.Add("@EmployeeID", createProductDto.EmployeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

		public async Task<GetProductByProductIDDto> GetProductByProductID(int id)
		{
			string query = "Select ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,CategoryName,ProductImage,ProductAddress,ProductType,DealOfTheDay from Product inner join Category on Product.ProductCategory=Category.CategoryID where ProductID=@productid";
			var parameters = new DynamicParameters();
			parameters.Add("@productid", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<GetProductByProductIDDto>(query, parameters);
                return values.FirstOrDefault();
			}
            
		}

		public async Task<GetProductDetailByIDDto> GetProductDetailByProductID(int id)
		{
            string query = "Select * from ProductDetails Where ProductID=@productid";
			var parameters = new DynamicParameters();
			parameters.Add("@productid", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<GetProductDetailByIDDto>(query, parameters);
				return values.FirstOrDefault();
			}
		}
	}
} 
