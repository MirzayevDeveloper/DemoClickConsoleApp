using ClickDemo.Main_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClickDemo.Cards;
namespace ClickDemo.Cards
{
    public class UzCard
    {
        public static void GetUzCard()
        {
            string info = "Uzcard information";

            bool isActive = true;
            while (isActive)
            {
                Console.Clear();
                Console.Write("1.UzCard Information\n2.Order UzCard\n0.Back\nchoose option: ");
                int i  = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 0:
                        {
                            return;
                        }
                        //break;
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine($"{info}\nPress any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        {
                            OrderCard.GetCardInfo();
                            return;
                        }
                        
                        default:
                        {
                            Console.Clear() ;
                        }
                        break;
                }
            }
        }
    }
}
