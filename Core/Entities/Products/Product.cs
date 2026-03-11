using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Products
{
    public class Product:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        [ForeignKey(name:nameof(CategoryId))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Photo> Photos { get; set; }
    }
}
