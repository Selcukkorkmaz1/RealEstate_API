using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.ServicesDto;
using RealEstate_API.Repositories.ServiceRepositories;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesRepository _servicesRepository;

        public ServiceController(IServicesRepository servicesRepository )
        {
            _servicesRepository = servicesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ServicesList()
        {
            var values = await _servicesRepository.GetAllServiceAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServicesDto createServicesDto)
        {
            _servicesRepository.CreateServices(createServicesDto);
            return Ok("Service Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            _servicesRepository.DeleteServices(id);
            return Ok("Service Başarılı Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServicesDto updateServicesDto)
        {
            _servicesRepository.UpdateServices(updateServicesDto);
            return Ok("Service Başarılı Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var values = await _servicesRepository.GetByIDServices(id);
            return Ok(values);
        }
    }
}
