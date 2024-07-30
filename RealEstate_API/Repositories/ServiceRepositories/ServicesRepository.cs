using Dapper;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.ServicesDto;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.ServiceRepositories
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly Context _context;

        public ServicesRepository(Context context)
        {
            _context = context;
        }
        public async void CreateServices(CreateServicesDto createServices)
        {         
                string query = "insert into Service (ServiceName,ServiceStatus) values (@name,@status)";
                var parameters = new DynamicParameters();
                parameters.Add("@name", createServices.ServiceName);
                parameters.Add("@status", true);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            
        }

        public async void DeleteServices(int id)
        {

            
                string query = "Delete from Service where ServiceID=@Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            
        }

        public async Task<List<ResultServicesDto>> GetAllServiceAsync()
        {

            
                string query = "Select * from Service";
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultServicesDto>(query);
                    return values.ToList();
                }

            
        }

        public async Task<GetByIDServicesDto> GetByIDServices(int id)
        {

            
                string query = "select * from Service where ServiceID=@id ";
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryFirstOrDefaultAsync<GetByIDServicesDto>(query, parameters);
                    return values;
                }
            
        }

        public async void UpdateServices(UpdateServicesDto updateServices)
        {

            
                string query = "Update Service set ServiceName=@name,ServiceStatus=@status where ServiceID=@id";
                var parameters = new DynamicParameters();
                parameters.Add("@name", updateServices.ServiceName);
                parameters.Add("@status", updateServices.ServiceStatus);
                parameters.Add("@id", updateServices.ServiceID);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }

            
        }
    }
}
