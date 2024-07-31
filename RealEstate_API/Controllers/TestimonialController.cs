using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.TestimonialDtos;
using RealEstate_API.Repositories.TestimonialRepositories;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialRepository _estimonialRepository;

        public TestimonialController(ITestimonialRepository estimonialRepository)
        {
            _estimonialRepository = estimonialRepository;
        }
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _estimonialRepository.GetAllTestimonialAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonial)
        {
            _estimonialRepository.CreateTestimonial(createTestimonial);
            return Ok("Comment Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            _estimonialRepository.DeleteTestimonial(id);
            return Ok("Comment Başarılı Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonial)
        {
            _estimonialRepository.UpdateTestimonial(updateTestimonial);
            return Ok("Comment Başarılı Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var values = await _estimonialRepository.GetByIdTestimonial(id);
            return Ok(values);
        }
    }
}
