﻿namespace RealEstate_API.Dtos.ProductDtos
{
    public class ResultLast5ProductWithCategoryDto
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public int ProductCategory { get; set; }
        public string CategoryName { get; set; }
        public DateTime Date { get; set; }
    }
}
