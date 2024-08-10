namespace RealEstate_API.Repositories.StatisticsRepositories
{
	public interface IStatisticsRepository
	{
		int CategoryCount();
		int ActiveCategoryCount();
		int PassiveCategoryCount();
		int ProductCount();
		int AppertmentCount();
		string EmployeNameByMaxProductCount();
		string CategoryNameByMaxProductCount();
		decimal AverageProductPriceBySale();
		decimal AverageProductPriceByRent();
		string CityNameByMaxProductCount();
		int DifferentCityCount();
		decimal LastProductPrice();
		string NewestBuildingYear();
		string OldestBuildingYear();
		int AverageRoomCount();
		int ActiveEmployeCount();

	}
}
