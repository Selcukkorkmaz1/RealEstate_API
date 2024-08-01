using RealEstate_API.Dtos.EmployeDtos;

namespace RealEstate_API.Repositories.EmplooyeRepositories
{
	public interface IEmployeRepository
	{
		Task<List<ResultEmployeDto>> GetAllEmployeAsync();
		void CreateEmploye(CreateEmployeDto createEmploye);
		void DeleteEmploye(int id);
		void UpdateEmploye(UpdateEmployeDto updateEmploye);
		Task<GetByIdEmployeDto> GetByIdEmploye(int id);
	}
}
