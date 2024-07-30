using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.ServicesDto;

namespace RealEstate_API.Repositories.ServiceRepositories
{
    public interface IServicesRepository
    {
        Task<List<ResultServicesDto>> GetAllServiceAsync();
        void CreateServices(CreateServicesDto createServices);
        void DeleteServices(int id);
        void UpdateServices(UpdateServicesDto updateServices);
        Task<GetByIDServicesDto> GetByIDServices(int id);
    }
}
