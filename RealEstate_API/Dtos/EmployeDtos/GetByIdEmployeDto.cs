﻿namespace RealEstate_API.Dtos.EmployeDtos
{
	public class GetByIdEmployeDto
	{
		public int EmployeID { get; set; }
		public string EmployeName { get; set; }
		public string EmployeTitle { get; set; }
		public string EmployeMail { get; set; }
		public string EmployePhone { get; set; }
		public string EmployeImageUrl { get; set; }
		public bool EmployeStatus { get; set; }
	}
}
