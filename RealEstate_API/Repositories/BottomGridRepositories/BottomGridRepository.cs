using Dapper;
using RealEstate_API.Dtos.BottomGridDto;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }
        public async void CreateBottomGrid(CreateBottomGridDto createBottomGrid)
        {

                string query = "insert into BottomGrid (BottomIcon,BottomTitle,BottomDescription) values (@ıcon,@title,@description)";
                var parameters = new DynamicParameters();
                parameters.Add("@ıcon", createBottomGrid.BottomIcon);
                parameters.Add("@title", createBottomGrid.BottomTitle);
                parameters.Add("@description", createBottomGrid.BottomDescription);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            
        }

        public async void DeleteBottomGrid(int id)
        {

            
                string query = "Delete from BottomGrid where BottomGridID=@Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {

            
                string query = "Select * from BottomGrid";
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                    return values.ToList();
                }

            
        }

      

        public async Task<GetByIdBottomGridDto> GetByIdBottomGrid(int id)
        {

            
                string query = "select * from BottomGrid where BottomGridID=@id ";
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(query, parameters);
                    return values;
                }
            
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto updateBottomGrid)
        {

            
                string query = "Update BottomGrid set BottomIcon=@ıcon,BottomTitle=@title,BottomDescription=@description where BottomGridID=@id";
                var parameters = new DynamicParameters();
                parameters.Add("@ıcon", updateBottomGrid.BottomIcon);
                parameters.Add("@title", updateBottomGrid.BottomTitle);
                parameters.Add("@description", updateBottomGrid.BottomDescription);
                parameters.Add("@id", updateBottomGrid.BottomGridID);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }

            
        }
    }
}
