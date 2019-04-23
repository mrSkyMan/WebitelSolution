using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webitel.Models
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        [Required]
        public Order Order { get; set; }
        [Required]
        public Product Product { get; set; }
    }
}
