using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Models.DapperContext;
using Dapper;

namespace RealEstate_API.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName,CategoryStatus) values (@name,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", categoryDto.CategoryName);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
            


                    
        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete from Category where CategoryID=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * from Category";
            using (var connection = _context.CreateConnection())
            {
                var values =await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }

        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "select * from Category where CategoryID=@id ";
            var parameters = new DynamicParameters();
            parameters.Add("@id",id);
            using(var connection = _context.CreateConnection())
            {
               var values= await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query,parameters);
                return values;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category set CategoryName=@name,CategoryStatus=@status where CategoryID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", categoryDto.CategoryName);
            parameters.Add("@status", categoryDto.CategoryStatus);
            parameters.Add("@id", categoryDto.CategoryID);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
