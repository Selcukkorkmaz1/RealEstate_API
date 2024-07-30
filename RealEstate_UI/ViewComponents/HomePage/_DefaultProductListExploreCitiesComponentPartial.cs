using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.PopLocationDtos;

namespace RealEstate_UI.ViewComponents.HomePage
{
    public class _DefaultProductListExploreCitiesComponentPartial:ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultProductListExploreCitiesComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44327/api/PopLocation");
			if (responseMessage.IsSuccessStatusCode)//200 - 299 Arası Değer Döner ise Çalısır
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultPopLocationDto>>(jsondata);//Json değeri List Dönüştürür
				return View(values);
			}
			return View();
		}
    }
}
