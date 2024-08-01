namespace RealEstate_UI.Dtos.ProductDtos
{
	public class CreateProductDto
	{
		public int productID { get; set; }
		public string productTitle { get; set; }
		public decimal productPrice { get; set; }
		public string productCity { get; set; }
		public string productDistrict { get; set; }
		public string categoryName { get; set; }
		public string ProductImage { get; set; }
		public string ProductType { get; set; }
		public string ProductAddress { get; set; }
	}
}
