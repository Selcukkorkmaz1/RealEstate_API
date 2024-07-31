using RealEstate_API.Dtos.ServicesDto;
using RealEstate_API.Dtos.TestimonialDtos;

namespace RealEstate_API.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        void CreateTestimonial(CreateTestimonialDto createTestimonial);
        void DeleteTestimonial(int id);
        void UpdateTestimonial(UpdateTestimonialDto updateTestimonial);
        Task<GetByIdTestimonialDto> GetByIdTestimonial(int id);
    }
}
