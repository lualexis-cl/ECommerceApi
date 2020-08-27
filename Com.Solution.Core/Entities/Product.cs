using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Com.Solution.Core.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        [Required]
        public int ProductBrandId { get; set; }
    }
}
