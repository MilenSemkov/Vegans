using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopVegieAndFruitMS.Model
{
    public class Vegan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }

        public int TypeId { get; set; }
        public VeganType VeganTypes { get; set; } 
    }
}
