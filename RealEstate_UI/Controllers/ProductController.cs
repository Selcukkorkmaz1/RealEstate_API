using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.ProductDtos;

namespace RealEstate_UI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client=_httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync("https://localhost:44327/api/Product/ProductListWithCategory");
				if(responsemessage.IsSuccessStatusCode)
			
				{
					var jsondata=await responsemessage.Content.ReadAsStringAsync();
					var values=JsonConvert.DeserializeObject<List<ResultProductDto>>(jsondata);
					return View(values);	
				}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult>CreateProduct()
		{
			return View();
		}
	}
}
