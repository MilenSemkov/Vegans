using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopVegieAndFruitMS.Model
{
    public class VegansContext:DbContext
    {
        public VegansContext():base("VegansContext")
        {

        }
        public DbSet<Vegan> Vegans { get; set; }
        public DbSet<VeganType> VeganTypes { get; set; }
    }
}
