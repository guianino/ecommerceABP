using System;
using System.ComponentModel.DataAnnotations;


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