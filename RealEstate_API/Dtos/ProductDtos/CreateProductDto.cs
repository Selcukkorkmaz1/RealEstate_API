namespace RealEstate_API.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductTitle { get; set; }
        public int ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public string ProductImage { get; set; }
        public string ProductAddress { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime Date { get; set; }
        public bool ProductStatus { get; set; }
        public int ProductCategory { get; set; }
        public int EmployeID { get; set; }
    }
}
