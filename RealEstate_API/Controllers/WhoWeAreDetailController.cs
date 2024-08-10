using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Dtos.WhoWeAreDtos;
using RealEstate_API.Repositories.WhoWeAreRepositories;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreRepository _whoWeAreRepository;

        public WhoWeAreDetailController(IWhoWeAreRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }
        [HttpGet]
        public async Task<IActionResult> WhoWeAreList()
        {
            var values = await _whoWeAreRepository.GetAllWhoWeAreAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAre)
        {
            _whoWeAreRepository.CreateWhoWeAre(createWhoWeAre);
            return Ok("Hakkımızda Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAre(int id)
        {
            _whoWeAreRepository.DeleteWhoWeAre(id);
            return Ok("Hakkımızda Başarılı Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAre)
        {
            _whoWeAreRepository.UpdateWhoWeAre(updateWhoWeAre);
            return Ok("Hakkımızda Başarılı Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAre(int id)
        {
            var values = await _whoWeAreRepository.GetWhoWeAre(id);
            return Ok(values);
        }
    }
}
