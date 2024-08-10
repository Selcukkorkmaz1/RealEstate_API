using Dapper;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.StatisticsRepositories
{
	public class StatisticsRepository : IStatisticsRepository
	{
		private readonly Context _context;

		public StatisticsRepository(Context context)
		{
			_context = context;
		}
		public int ActiveCategoryCount()
		{
			string query = "Select Count(*) From Category where CategoryStatus=1";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ActiveEmployeCount()
		{
			string query = "Select Count(*) From Employee where EmployeStatus=1";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int AppertmentCount()
		{
			string query = "Select Count(*) From Product where ProductTitle like '%Daire%'";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public decimal AverageProductPriceByRent()
		{
			string query = "Select Avg(ProductPrice) From Product where ProductType='Kiralık'";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<decimal>(query);
				return values;
			}
		}

		public decimal AverageProductPriceBySale()
		{
			string query = "Select Avg(ProductPrice) From Product where ProductType='Satılık'";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<decimal>(query);
				return values;
			}
		}

		public int AverageRoomCount()
		{
			string query = "Select Avg(RoomCount) From ProductDetails";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int CategoryCount()
		{
			string query = "Select Count(*) From Category";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public string CategoryNameByMaxProductCount()
		{
			string query = "Select top(1) CategoryName,Count(*) From Product inner join Category On Product.ProductCategory=Category.CategoryID Group By CategoryName order by Count(*) Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public string CityNameByMaxProductCount()
		{
			string query = "Select Top(1) ProductCity,Count(*) as 'product_count' From Product Group By ProductCity order by product_count Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public int DifferentCityCount()
		{
			string query = "Select Count(ProductCity) From Product";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public string EmployeNameByMaxProductCount()
		{
			string query = "Select EmployeName,Count(*) 'product_count' From Product Inner Join Employee On Product.EmployeID=Employee.EmployeID Group By EmployeName Order By product_count Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public decimal LastProductPrice()
		{
			string query = "Select Top(1) ProductPrice From Product Order By ProductID Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<decimal>(query);
				return values;
			}
		}

		public string NewestBuildingYear()
		{
			string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear-1 Asc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public string OldestBuildingYear()
		{
			string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear-1 Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public int PassiveCategoryCount()
		{
			string query = "Select Count(*) From Category Where CategoryStatus=0";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ProductCount()
		{
			string query = "Select Count(*) From Product";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}
	}
}
