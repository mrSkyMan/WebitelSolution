using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webitel.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Number { get; set; }
        [Required]
        [DataType("decimal(18 ,0")]
        public decimal Amount { get; set; }
    }
}
