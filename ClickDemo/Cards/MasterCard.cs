using ClickDemo.Main_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickDemo.Cards
{
    public class MasterCard
    {
        public static void GetMasterCard()
        {
            string info = "MasterCard information";

            bool isActive = true;
            while (isActive)
            {
                Console.Clear();
                Console.Write("1.MasterCard Information\n2.Order MasterCard\n0.Back\nchoose option: ");
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
