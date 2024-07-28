using Dapper;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.WhoWeAreDtos;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.WhoWeAreRepositories
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }
        public async void CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto)
        {
            string query = "insert into WhoWeAreDetail (Title,SubTitle,Description1,Description2) values (@title,@subtitle,@des1,@des2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDto.Title);
            parameters.Add("@subtitle", createWhoWeAreDto.SubTitle);
            parameters.Add("@des1", createWhoWeAreDto.Description1);
            parameters.Add("@des2", createWhoWeAreDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAre(int id)
        {

            string query = "Delete from WhoWeAreDetail where WhoWeAreID=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }


        public async Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreAsync()
        {
            string query = "Select * from WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDto>(query);
                return values.ToList();
            }

        }

        public async Task<GetByWhoWeAreDto> GetWhoWeAre(int id)
        {
                string query = "select * from WhoWeAreDetail where WhoWeAreID=@id ";
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryFirstOrDefaultAsync<GetByWhoWeAreDto>(query, parameters);
                    return values;
                }
        }

        public async void UpdateWhoWeAre(UpdateWhoWeAreDto whoWeAreDto)
        {          
                string query = "Update WhoWeAreDetail set Title=@title,SubTitle=@subtitle,Description1=@des1,Description2=@des2 where WhoWeAreID=@id";
                var parameters = new DynamicParameters();
                parameters.Add("@title", whoWeAreDto.Title);
                parameters.Add("@subtitle", whoWeAreDto.SubTitle);
                parameters.Add("@des1", whoWeAreDto.Description1);
                parameters.Add("@des2", whoWeAreDto.Description2);
                parameters.Add("@id", whoWeAreDto.WhoWeAreID);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
        }
    }
}

