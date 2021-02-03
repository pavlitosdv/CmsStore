using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string Name { get; set; }

        public string Slug { get; set; }

        [Required, MinLength(4, ErrorMessage = "Minimum length is 4")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        [Range(1, int.MaxValue, ErrorMessage = "You must choose a category")] // at the Select list will also the value of 0 that displays a message
                                                                            //so we skip that by adding a range starting from 1
        public int CategoryId { get; set; }

        public string Image { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [NotMapped]
        //[FileExtension]
        public IFormFile ImageUpload { get; set; }
    }
}
