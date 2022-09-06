using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DbCrud.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(2)]
        public string CatCode { get; set; }
        [Required]
        [StringLength(100)]
        public string CatName { get; set; }

        [InverseProperty(nameof(Product.CategoryNavigation))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
