using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.ViewModels
{
    public class OrderCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        //public Status Status { get; set; }
        [Required]
        public int Table { get; set; }
        [Required]
        public string FoodName { get; set; }
    }
}
