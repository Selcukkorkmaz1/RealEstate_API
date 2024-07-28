using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.WhoWeAreDtos;

namespace RealEstate_API.Repositories.WhoWeAreRepositories
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreAsync();
        void CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto);
        void DeleteWhoWeAre(int id);
        void UpdateWhoWeAre(UpdateWhoWeAreDto whoWeAreDto);
        Task<GetByWhoWeAreDto> GetWhoWeAre(int id);
    }
}
