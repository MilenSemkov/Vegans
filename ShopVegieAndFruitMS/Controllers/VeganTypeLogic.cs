using ShopVegieAndFruitMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopVegieAndFruitMS.Controllers
{
    public class VeganTypeLogic
    {
        private VegansContext _veganTypesDbContext = new VegansContext();
        public List<VeganType> GetAllTypes()
        {
            return _veganTypesDbContext.VeganTypes.ToList();
        }
        public string GetTypeById(int id)
        {
            return _veganTypesDbContext.VeganTypes.Find(id).NameType;
        }
    }
}
