using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.DTOs
{
    public class ItemDTO
    {
        public int Item_Id { get; set; }
        public int List_Id { get; set; }
        [Required(ErrorMessage = "Item Name is required")]
        public string Item_Name { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [RegularExpression(@"^[^\s\d]+$", ErrorMessage = "Category should not contain spaces, digits, or special characters")]
        public string Category { get; set; }
        public string IsBought { get; set; }
        [Required(ErrorMessage = "Estimated Price is required")]
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage = "Estimated Price should be a decimal number")]
        public decimal Estimated_Price { get; set; }
    }
}