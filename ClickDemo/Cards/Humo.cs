using ClickDemo.Main_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClickDemo.Cards;

namespace ClickDemo.Cards
{
    public class Humo
    {
        public static void GetHumo()
        {
            string info = "Humo information";

            bool isActive = true;
            while (isActive)
            {
                Console.Clear();
                Console.Write("1.Humo Information\n2.Order Humo\n0.Back\nchoose option: ");
                int i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            Console.WriteLine($"{info}\nPress any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        {
                            OrderCard.GetCardInfo();
                        }
                        break;
                    default:
                        {
                            Console.Clear();
                        }
                        break;
                }
            }
        }
    }
}
