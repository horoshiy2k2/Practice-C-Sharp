using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson11
{
    static class Backet
    {
        static List<IProduct> products = new List<IProduct>();
        static int lengthList = 10;
        static Backet()
        {
            var r = new Random();
            for (int i = 0; i < lengthList; i++)
            {
                switch (r.Next(1, 4)) // 1 2 3
                {
                    case 1:
                        products.Add(new Gum() { Name = $"Gum{i + 1}", Cost = r.Next(1, 10), CountInPack = r.Next(1, 10) });
                        break;
                    case 2:
                        products.Add(new Jeans() { Name = $"Jeans{i + 1}", Cost = r.Next(10, 100), Color = (Colors)r.Next(0, 6), Made = "Made" + (i + 1) }); // переделать.
                        break;
                    case 3:
                        products.Add(new Toy() { Name = $"Toy{i + 1}", Cost = r.Next(1, 50), MaterialToy = (Material)r.Next(0, 3), AgeCategory = r.Next(0, 13) });
                        break;
                    default:
                        break;
                }
            }
        }

        static public void Show(){
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
