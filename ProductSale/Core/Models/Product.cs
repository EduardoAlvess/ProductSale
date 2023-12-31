﻿using System.ComponentModel.DataAnnotations;

namespace ProductSale.Core.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public bool isDeleted { get; set; }
        public int AmountInStock { get; set; }
        public string Description { get; set; }
        public double ProductionCost { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
