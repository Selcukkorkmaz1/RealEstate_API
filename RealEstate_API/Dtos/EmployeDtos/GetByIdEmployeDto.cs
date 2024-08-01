namespace RealEstate_API.Dtos.EmployeDtos
{
	public class GetByIdEmployeDto
	{
		public int EmployeID { get; set; }
		public String EmployeName { get; set; }
		public String EmployeTitle { get; set; }
		public String EmployeMail { get; set; }
		public String EmployePhone { get; set; }
		public String EmployeImageUrl { get; set; }
		public bool EmployeStatus { get; set; }
	}
}
