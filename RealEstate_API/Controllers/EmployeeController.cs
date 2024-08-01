using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Dtos.EmployeDtos;
using RealEstate_API.Repositories.EmplooyeRepositories;

namespace RealEstate_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeRepository _employeRepository;

		public EmployeeController(IEmployeRepository employeRepository)
		{
			_employeRepository = employeRepository;
		}

		[HttpGet]
		public async Task<IActionResult> EmployeList()
		{
			var values = await _employeRepository.GetAllEmployeAsync();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateEmploye(CreateEmployeDto createEmploye)
		{
			_employeRepository.CreateEmploye(createEmploye);
			return Ok("Employe Başarılı Bir Şekilde Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEmploye(int id)
		{
			_employeRepository.DeleteEmploye(id);
			return Ok("Employee Başarılı Şekilde Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateEmploye(UpdateEmployeDto updateEmploye)
		{
			_employeRepository.UpdateEmploye(updateEmploye);
			return Ok("Employe Başarılı Şekilde Güncellendi");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdEmploye(int id)
		{
			var values = await _employeRepository.GetByIdEmploye(id);
			return Ok(values);
		}
	}
}
