using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Musilu.Eshop.Web.Models.Entity
{
    public class Product
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }


        [Required]
        public double Price { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [StringLength(255)]
        [Required]
        public string ImageSource { get; set; }

        [StringLength(50)]
        public string ImageAlt { get; set; }

    }
}
