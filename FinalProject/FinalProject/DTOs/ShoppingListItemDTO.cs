using FinalProject.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.DTOs
{
    public class ShoppingListItemDTO
    {
        public int List_Id { get; set; }
        public int User_Id { get; set; }
        public string List_Name { get; set; }
        public System.DateTime C_Date { get; set; }
        public virtual ICollection<ItemDTO> Items { get; set; }
    }
}