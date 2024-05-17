using ShopVegieAndFruitMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopVegieAndFruitMS.Controllers
{
    public class VeganLogic
    {
        private VegansContext _vegansDbContext = new VegansContext();
        public Vegan Get(int id)
        {
            Vegan findedVegan = _vegansDbContext.Vegans.Find(id);
            if (findedVegan != null)
            {
                _vegansDbContext.Entry(findedVegan).Reference(x => x.VeganTypes).Load();
            }
            return findedVegan;
        }
        public List<Vegan> GetAll()
        {
            return _vegansDbContext.Vegans.Include("VeganTypes").ToList();
        }
        public void Create(Vegan vegan)
        {
            _vegansDbContext.Vegans.Add(vegan);
            _vegansDbContext.SaveChanges();
        }
        public void Update(int id, Vegan vegan)
        {
            Vegan findedVegan = _vegansDbContext.Vegans.Find(id);
            if (findedVegan == null)
            {
                return;
            }
            findedVegan.Name = vegan.Name;
            findedVegan.Discription = vegan.Discription;
            findedVegan.Price = vegan.Price;
            _vegansDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Vegan findedVegan = _vegansDbContext.Vegans.Find(id);
            _vegansDbContext.Vegans.Remove(findedVegan);
            _vegansDbContext.SaveChanges();
            
        }


    }
}
