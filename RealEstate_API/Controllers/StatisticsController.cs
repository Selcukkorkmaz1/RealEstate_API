using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Repositories.CategoryRepositories;
using RealEstate_API.Repositories.StatisticsRepositories;

namespace RealEstate_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatisticsController : ControllerBase
	{
		private readonly IStatisticsRepository _statisticsRepository;

		public StatisticsController(IStatisticsRepository statisticsRepository)
		{
			_statisticsRepository = statisticsRepository;
		}

		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			return Ok(_statisticsRepository.ActiveCategoryCount());
		}

		[HttpGet("ActiveEmployeCount")]
		public IActionResult ActiveEmployeeCount()
		{
			return Ok(_statisticsRepository.ActiveEmployeCount());
		}

		[HttpGet("AppertmentCount")]
		public IActionResult AppertmentCount()
		{
			return Ok(_statisticsRepository.AppertmentCount());
		}

		[HttpGet("AverageProductPriceByRent")]
		public IActionResult AverageProductPriceByRent()
		{
			return Ok(_statisticsRepository.AverageProductPriceByRent());
		}

		[HttpGet("AverageProductPriceBySale")]
		public IActionResult AverageProductPriceBySale()
		{
			return Ok(_statisticsRepository.AverageProductPriceBySale());
		}

		[HttpGet("AverageRoomCount")]
		public IActionResult AverageRoomCount()
		{
			return Ok(_statisticsRepository.AverageRoomCount());
		}

		[HttpGet("CategoryCount")]
		public IActionResult CategoryCount()
		{
			return Ok(_statisticsRepository.CategoryCount());
		}

		[HttpGet("CategoryNameByMaxProductCount")]
		public IActionResult CategoryNameByMaxProductCount()
		{
			return Ok(_statisticsRepository.CategoryNameByMaxProductCount());
		}

		[HttpGet("CityNameByMaxProductCount")]
		public IActionResult CityNameByMaxProductCount()
		{
			return Ok(_statisticsRepository.CityNameByMaxProductCount());
		}

		[HttpGet("DifferentCityCount")]
		public IActionResult DifferentCityCount()
		{
			return Ok(_statisticsRepository.DifferentCityCount());
		}

		[HttpGet("EmployeNameByMaxProductCount")]
		public IActionResult EmployeNameByMaxProductCount()
		{
			return Ok(_statisticsRepository.EmployeNameByMaxProductCount());
		}

		[HttpGet("LastProductPrice")]
		public IActionResult LastProductPrice()
		{
			return Ok(_statisticsRepository.LastProductPrice());
		}

		[HttpGet("NewestBuildingYear")]
		public IActionResult NewestBuildingYear()
		{
			return Ok(_statisticsRepository.NewestBuildingYear());
		}

		[HttpGet("OldestBuildingYear")]
		public IActionResult OldestBuildingYear()
		{
			return Ok(_statisticsRepository.OldestBuildingYear());
		}

		[HttpGet("PassiveCategoryCount")]
		public IActionResult PassiveCategoryCount()
		{
			return Ok(_statisticsRepository.PassiveCategoryCount());
		}

		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{
			return Ok(_statisticsRepository.ProductCount());
		}
	}
}
