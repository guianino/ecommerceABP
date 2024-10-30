using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Costumers
{
    public class CreateCostumerDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    
        [Required]
        public string Document { get; set; }
    }
}