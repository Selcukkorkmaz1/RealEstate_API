using RealEstate_API.Dtos.BottomGridDto;
using RealEstate_API.Dtos.CategoryDtos;

namespace RealEstate_API.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDto createBottomGrid);
        void DeleteBottomGrid(int id);
        void UpdateBottomGrid(UpdateBottomGridDto updateBottomGrid);
        Task<GetByIdBottomGridDto> GetByIdBottomGrid(int id);
    }
}
