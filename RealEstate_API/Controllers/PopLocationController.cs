using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Dtos.BottomGridDto;
using RealEstate_API.Dtos.PopulerLocationDtos;
using RealEstate_API.Repositories.PopLocationRepositories;

namespace RealEstate_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PopLocationController : ControllerBase
	{
		private readonly IPopLocationRepository _popLocationRepository;

		public PopLocationController(IPopLocationRepository popLocationRepository)
		{
			_popLocationRepository = popLocationRepository;
		}

		[HttpGet]
		public async Task<IActionResult> PopLocationList()
		{
			var values = await _popLocationRepository.GetAllLocationAsync();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreatePopLocation(CreatePopLocationDto createPopLocation)
		{
			_popLocationRepository.CreatePopLocation(createPopLocation);
			return Ok("Location Başarılı Bir Şekilde Eklendi");
		}
		[HttpDelete ("{id}")]
		public async Task<IActionResult> DeletePopLocation(int id)
		{
			_popLocationRepository.DeletePopLocation(id);
			return Ok("Location Başarılı Şekilde Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdatePopLocation(UpdatePopLocationDto updatePopLocation)
		{
			_popLocationRepository.UpdatePopLocation(updatePopLocation);
			return Ok("Location Başarılı Şekilde Güncellendi");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBottomGrid(int id)
		{
			var values = await _popLocationRepository.GetByIdLocation(id);
			return Ok(values);
		}
	}
}
