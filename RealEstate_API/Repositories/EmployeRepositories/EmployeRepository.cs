using Dapper;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.EmployeDtos;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.EmplooyeRepositories
{
	public class EmployeRepository : IEmployeRepository
	{
		private readonly Context _context;

		public EmployeRepository(Context context)
		{
			_context = context;
		}
		public async void CreateEmploye(CreateEmployeDto createEmploye)
		{
			string query = "insert into Employee (EmployeName,EmployeTitle,EmployeMail,EmployePhone,EmployeImageUrl,EmployeStatus) values (@name,@title,@mail,@phone,@url,@status)";
			var parameters = new DynamicParameters();
			parameters.Add("@name", createEmploye.EmployeName);
			parameters.Add("@name", createEmploye.EmployeTitle);
			parameters.Add("@name", createEmploye.EmployeMail);
			parameters.Add("@name", createEmploye.EmployePhone);
			parameters.Add("@name", createEmploye.EmployeImageUrl);
			parameters.Add("@status", true);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async void DeleteEmploye(int id)
		{
			string query = "Delete from Employee where EmployeID=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultEmployeDto>> GetAllEmployeAsync()
		{
			string query = "Select * from Employee";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultEmployeDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIdEmployeDto> GetByIdEmploye(int id)
		{
			string query = "select * from Employee where EmployeID=@id ";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeDto>(query, parameters);
				return values;
			};
		}

		public async void UpdateEmploye(UpdateEmployeDto updateEmploye)
		{
			string query = "Update Employee set EmployeName=@name,EmployeTitle=@title,EmployeMail=@mail,EmployePhone=@phone,EmployeImageUrl=@url,EmployeStatus=@status where EmployeID=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@name",updateEmploye.EmployeName);
			parameters.Add("@title",updateEmploye.EmployeTitle);
			parameters.Add("@mail",updateEmploye.EmployeMail);
			parameters.Add("@phone",updateEmploye.EmployePhone);
			parameters.Add("@url",updateEmploye.EmployeImageUrl);
			parameters.Add("@status",updateEmploye.EmployeStatus);
			parameters.Add("@id",updateEmploye.EmployeID);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
 