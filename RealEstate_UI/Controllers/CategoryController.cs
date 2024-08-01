using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.CategoryDtos;
using System.Text;

namespace RealEstate_UI.Controllers
{
    public class CategoryController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44327/api/Categories");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View();	
		}
		[HttpPost]
		public async Task<IActionResult>CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var client =_httpClientFactory.CreateClient();
			var jsondata=JsonConvert.SerializeObject(createCategoryDto);
			StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"application/json");//(türü,türkçe dil desteği,medya türü)
			var responsemessage = await client.PostAsync("https://localhost:44327/api/Categories", stringContent);
			if (responsemessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult>DeleteCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44327/api/Categories/{id}");
			if(responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateCategory(int id)
		{
			var client=_httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync($"https://localhost:44327/api/Categories/{id}");
			if (responsemessage.IsSuccessStatusCode)
			{
				var jsondata=await responsemessage.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<UpdateCategoryDto>(jsondata);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
		{
			var client=_httpClientFactory.CreateClient();
			var jsondata=JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"application/json");
			var responsemessage = await client.PutAsync("https://localhost:44327/api/Categories", stringContent);
			if(responsemessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
