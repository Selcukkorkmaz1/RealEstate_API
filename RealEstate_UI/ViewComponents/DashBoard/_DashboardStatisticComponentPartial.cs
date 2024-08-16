using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.DashBoard
{
    public class _DashboardStatisticComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Statistics1 - Top İlan Sayısı
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44327/api/Statistics/ProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion


            #region Statistics2 - En Pop Çalışan
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44327/api/Statistics/EmployeNameByMaxProductCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData2;
            #endregion

            #region Statistics3 - Top.Şehir
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44327/api/Statistics/DifferentCityCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData3;
            #endregion

            #region Statistics4 - OrtalamaKiraFiyatı
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44327/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData4;
            #endregion

            return View();
        }
    }
}
