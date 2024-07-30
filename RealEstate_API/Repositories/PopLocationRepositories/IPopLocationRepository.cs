using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.PopulerLocationDtos;

namespace RealEstate_API.Repositories.PopLocationRepositories
{
	public interface IPopLocationRepository
	{
		Task<List<ResultPopLocation>> GetAllLocationAsync();
		void CreatePopLocation(CreatePopLocationDto createPopLocation);
		void DeletePopLocation(int id);
		void UpdatePopLocation(UpdatePopLocationDto updatePopLocation);
		Task<GetByIdPopLocationDto> GetByIdLocation(int id);
	}
}
