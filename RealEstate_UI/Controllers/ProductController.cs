using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.CategoryDtos;
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
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44327/api/Categories");
		
				var jsondata=await responseMessage.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
			List<SelectListItem>categoryvalues=(from x in values.ToList() select new SelectListItem
			{
				Text=x.CategoryName,
				Value = x.CategoryID.ToString()
			}).ToList();

			ViewBag.v=categoryvalues;

			return View();
		}
	}
}
