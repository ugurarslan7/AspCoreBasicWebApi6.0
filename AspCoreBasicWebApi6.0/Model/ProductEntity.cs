using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCoreBasicWebApi6._0.Core
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

    }
}
