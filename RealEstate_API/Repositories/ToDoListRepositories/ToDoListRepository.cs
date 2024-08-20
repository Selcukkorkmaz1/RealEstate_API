using Dapper;
using RealEstate_API.Dtos.ToDoListDots;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.ToDoListRepositories
{
    public class ToDoListRepository:IToDoListRepository
    {
        private readonly Context _context;
        public ToDoListRepository(Context context)
        {
            _context = context;
        }
        public Task CreateToDoList(CreateToDoListDto ToDoListDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoList()
        {
            string query = "Select * From ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIDToDoListDto> GetToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoList(UpdateToDoListDto ToDoListDto)
        {
            throw new NotImplementedException();
        }
    }
}
