using Dapper;
using RealEstate_API.Dtos.ChartDtos;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly Context _context;
        public ChartRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultChartDto>> Get5CityForChart()
        {
            string query = "Select top(5) ProductCity,Count(*) as 'CityCount' From Product Group By ProductCity order By CityCount Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultChartDto>(query);
                return values.ToList();
            }
        }
    }
}
