using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.EmployeeDtos;
using RealEstate_UI.Services;
using System.Text;

namespace RealEstate_UI.Controllers
{
	[Authorize]
	public class EmployeeController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;


        public EmployeeController(IHttpClientFactory httpClientFactory, ILoginService loginService, IHttpContextAccessor contextAccessor)
		{
			_httpClientFactory = httpClientFactory;
            _loginService = loginService;

        }

        public async Task<IActionResult> Index()
		{
            var user = User.Claims;
            var userId = _loginService.GetUserId;


            var token = User.Claims.FirstOrDefault(x => x.Type == "realestatetoken")?.Value;
			if (token != null)
			{
				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.GetAsync("https://localhost:44327/api/Employee");
				if (responseMessage.IsSuccessStatusCode)
				{
					var jsondata = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<List<ResultEmployeDto>>(jsondata);
					return View(values);
				}
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateEmploye()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateEmploye(CreateEmployeDto createEmployeDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsondata = JsonConvert.SerializeObject(createEmployeDto);
			StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");//(türü,türkçe dil desteği,medya türü)
			var responsemessage = await client.PostAsync("https://localhost:44327/api/Employee", stringContent);
			if (responsemessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44327/api/Categories/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteEmploye(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44327/api/Employee/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateEmploye(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync($"https://localhost:44327/api/Employee/{id}");
			if (responsemessage.IsSuccessStatusCode)
			{
				var jsondata = await responsemessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateEmployeDto>(jsondata);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateEmploye(UpdateEmployeDto dto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsondata = JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
			var responsemessage = await client.PutAsync("https://localhost:44327/api/Employee", stringContent);
			if (responsemessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}