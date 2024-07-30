using Dapper;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.PopulerLocationDtos;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.PopLocationRepositories
{

	public class PopLocationRepository : IPopLocationRepository
	{
		private readonly Context _context;

		public PopLocationRepository(Context context)
		{
			_context = context;
		}
		public async  void CreatePopLocation(CreatePopLocationDto createPopLocation)
		{	
				string query = "insert into PopulerLocation (LocationName,LocationUrl) values (@name,@url)";
				var parameters = new DynamicParameters();
				parameters.Add("@name",createPopLocation.LocationName);
				parameters.Add("@url",createPopLocation.LocationUrl);
				using (var connection = _context.CreateConnection())
				{
					await connection.ExecuteAsync(query, parameters);
				}	
		}

		public async void DeletePopLocation(int id)
		{
				string query = "Delete from PopulerLocation where LocationID=@Id";
				var parameters = new DynamicParameters();
				parameters.Add("@Id", id);
				using (var connection = _context.CreateConnection())
				{
					await connection.ExecuteAsync(query, parameters);
				}
		}

		public async Task<List<ResultPopLocation>> GetAllLocationAsync()
		{
				string query = "Select * from PopulerLocation";
				using (var connection = _context.CreateConnection())
				{
					var values = await connection.QueryAsync<ResultPopLocation>(query);
					return values.ToList();
				}
		}

		public async Task<GetByIdPopLocationDto> GetByIdLocation(int id)
		{
				string query = "select * from PopulerLocation where LocationID=@id ";
				var parameters = new DynamicParameters();
				parameters.Add("@id", id);
				using (var connection = _context.CreateConnection())
				{
					var values = await connection.QueryFirstOrDefaultAsync<GetByIdPopLocationDto>(query, parameters);
					return values;
				}
		}

		public async void UpdatePopLocation(UpdatePopLocationDto updatePopLocation)
		{
				string query = "Update PopulerLocation set LocationName=@name,LocationUrl=@url where LocationID=@id";
				var parameters = new DynamicParameters();
			parameters.Add("@name", updatePopLocation.LocationName);
			parameters.Add("@url", updatePopLocation.LocationUrl);
			parameters.Add("@id", updatePopLocation.LocationID);
				using (var connection = _context.CreateConnection())
				{
					await connection.ExecuteAsync(query, parameters);
				}
		}
	}
}
