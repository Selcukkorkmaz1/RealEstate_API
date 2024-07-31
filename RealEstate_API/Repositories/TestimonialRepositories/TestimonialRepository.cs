using Dapper;
using RealEstate_API.Dtos.ServicesDto;
using RealEstate_API.Dtos.TestimonialDtos;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }
        public async void CreateTestimonial(CreateTestimonialDto createTestimonial)
        {

            
                string query = "insert into Testimonial (NameSurname,TestimonialStatus,Title,Comment) values (@name,@status,@title,@comment)";
                var parameters = new DynamicParameters();
            parameters.Add("@name", createTestimonial.NameSurname);
            parameters.Add("@title", createTestimonial.Title);
            parameters.Add("@comment", createTestimonial.Comment);
                parameters.Add("@status", true);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }

            
        }

        public async void DeleteTestimonial(int id)
        {
                string query = "Delete from Testimonial where TestimonialID=@Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
                string query = "Select * from Testimonial";
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                    return values.ToList();
                }
        }

        public  async Task<GetByIdTestimonialDto> GetByIdTestimonial(int id)
        {
                string query = "select * from Testimonial where TestimonialID=@id ";
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryFirstOrDefaultAsync<GetByIdTestimonialDto>(query, parameters);
                    return values;
                }
        }

        public async void UpdateTestimonial(UpdateTestimonialDto updateTestimonial)
        {
                string query = "Update Testimonial set NameSurname=@name,TestimonialStatus=@status,Title=@title,Comment=@comment where TestimonialID=@id";
                var parameters = new DynamicParameters();
            parameters.Add("@name", updateTestimonial.NameSurname);
            parameters.Add("@title", updateTestimonial.Title);
            parameters.Add("@status", updateTestimonial.TestimonialStatus);
            parameters.Add("@comment", updateTestimonial.Comment);
            parameters.Add("@id", updateTestimonial.TestimonialID);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
        }
    }
}
