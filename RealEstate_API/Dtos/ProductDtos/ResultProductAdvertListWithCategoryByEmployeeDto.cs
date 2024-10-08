﻿namespace RealEstate_API.Dtos.ProductDtos
{
    public class ResultProductAdvertListWithCategoryByEmployeeDto
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public int ProductCategory { get; set; }
        public string ProductImage { get; set; }
        public string ProductType { get; set; }
        public string ProductAddress { get; set; }
        public bool DealOfTheDay { get; set; }
        public bool ProductStatus { get; set; }

    }
}
