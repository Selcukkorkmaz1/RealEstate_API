﻿namespace RealEstate_UI.Dtos.ProductDtos
{
	public class CreateProductDto
	{
		public int productID { get; set; }
		public string productTitle { get; set; }
		public decimal productPrice { get; set; }
		public string productCity { get; set; }
		public string productDistrict { get; set; }
		public string categoryID { get; set; }
		public string ProductImage { get; set; }
		public string ProductType { get; set; }
		public string ProductAddress { get; set; }
        public string ProductDescription { get; set; }
        public string productType { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime Date { get; set; }
        public bool ProductStatus { get; set; }
        public int ProductCategory { get; set; }
        public int EmployeID { get; set; }
    }
}
