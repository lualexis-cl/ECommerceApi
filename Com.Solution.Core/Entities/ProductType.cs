using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Solution.Core.Entities
{
    public class ProductType : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
    }
}