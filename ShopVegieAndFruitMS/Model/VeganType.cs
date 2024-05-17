using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopVegieAndFruitMS.Model
{
    public  class VeganType
    {
        public int Id { get; set; }
        public string NameType { get; set; }

        public ICollection<Vegan> Vegans { get; set; }
    }
}
