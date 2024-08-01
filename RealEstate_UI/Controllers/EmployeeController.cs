using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.EmployeeDtos;

namespace RealEstate_UI.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public EmployeeController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44327/api/Employee");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultEmployeDto>>(jsondata);
				return View(values);
			}
			return View();
		}
	}
}