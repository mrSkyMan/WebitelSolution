using System;
using System.ComponentModel.DataAnnotations;

namespace Webitel.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType("decimal(18 ,0")]
        public decimal Price { get; set; }
    }
}
