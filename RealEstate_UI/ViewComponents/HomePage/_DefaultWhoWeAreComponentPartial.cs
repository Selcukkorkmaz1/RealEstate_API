using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var client2=_httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:44327/api/WhoWeAreDetail");
            var responsemessage2 = await client.GetAsync("https://localhost:44327/api/Service");
            if(responsemessage.IsSuccessStatusCode && responsemessage2.IsSuccessStatusCode)
            {
                var jsondata=await responsemessage.Content.ReadAsStringAsync();
                var jsondata2=await responsemessage2.Content.ReadAsStringAsync();

                var values=JsonConvert.DeserializeObject<List<ResultWhoWeAreDetail>>(jsondata);
                var values2=JsonConvert.DeserializeObject<List<ResultServicesDto>>(jsondata2);

                ViewBag.title =values.Select(x=>x.Title).FirstOrDefault();
                ViewBag.subtitle =values.Select(x=>x.SubTitle).FirstOrDefault();
                ViewBag.description1 =values.Select(x=>x.Description1).FirstOrDefault();
                ViewBag.description2 =values.Select(x=>x.Description2).FirstOrDefault();
                return View(values2);
            }
            return View();
        }
    }
}
