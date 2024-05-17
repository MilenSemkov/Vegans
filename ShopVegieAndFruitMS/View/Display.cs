using ShopVegieAndFruitMS.Controllers;
using ShopVegieAndFruitMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopVegieAndFruitMS.View
{
    public class Display
    {
        private VeganLogic veganLogic = new VeganLogic();
        private int closeOperation = 6;
        private Display()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all products");
            Console.WriteLine("2. Add new product");
            Console.WriteLine("3. Update product");
            Console.WriteLine("4. Find product by ID");
            Console.WriteLine("5. Delete product by ID");
            Console.WriteLine("6. Exit");
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        //ListAll();
                        break;
                    case 2:
                        //Add();
                        break;
                    case 3:
                        //Update();
                        break;
                    case 4:
                        //Find();
                        break;
                    case 5:
                        //Delete();
                        break;
                    default:
                        break;

                }
            } while (operation != closeOperation);
        }
        private void PrintVegan(Vegan vegan)
        {
            Console.WriteLine($"{vegan.Id}. {vegan.Name} Описание: {vegan.Discription} {vegan.Price}лв. Тип ID: {vegan.TypeId}");
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            VeganLogic veganController = new VeganLogic();
            Vegan vegan = veganController.Get(id);
            if (vegan!=null)
            {
                veganController.Delete(id);
            }
        }
        private void Find()
        {
            Console.WriteLine("Enter ID to find: ");
            int id = int.Parse(Console.ReadLine());
            VeganLogic veganController = new VeganLogic();
            Vegan vegan = veganController.Get(id);
            if (vegan != null)
            {
                PrintVegan(vegan);
            }
        }


    }
}
