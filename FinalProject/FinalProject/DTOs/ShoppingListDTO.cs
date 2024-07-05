using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.DTOs
{
    public class ShoppingListDTO
    {
        public int List_Id { get; set; }
        public int User_Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string List_Name { get; set; }
        public System.DateTime C_Date { get; set; }
    }
}