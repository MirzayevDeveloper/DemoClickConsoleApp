using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ClickDemo.Main_Menu;

namespace ClickDemo
{
    public class OldMenu
    {
        /// <summary>
        ///  int index = CardList.FindIndex(a => a.Contains(PassList[0]));
        /// </summary>
        const string FilePath = @"C:\Users\Asus\Documents\Text\DataBase.txt";
        const string location = @"C:\Users\Asus\Documents\Text\CardList.txt";
        const string BalancePath = @"C:\Users\Asus\Documents\Text\Balance.txt";
        
        //private string _sum = DataBase[7];
        static List<string> PassList = File.ReadAllLines(location).ToList();
        private static bool isTrue = true;
        //public double Balance { get; set; }
        //OldMenu OldWindow = new OldMenu();

        public static void SecondMenu()
        {
            int j = 0;
            

            while (isTrue) 
            {
                List<string> DataBase = File.ReadAllLines(FilePath).ToList();
                int index = DataBase.IndexOf(PassList[j]);
                string _balance = DataBase[index + 1];
                List<string> BalanceList = File.ReadAllLines(BalancePath).ToList();
                Console.Clear();
                Console.WriteLine($"Current {_balance}");
                Console.Write("1.Transfer\n2.History\n3.Add card\n4.Exit\nChoose option: ");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        {
                            Transfer.Transaction();
                        }
                        break; 
                    case 2:
                        {
                            History.CheckHistory();
                        }
                        break;
                    case 3:
                        {
                            MainMenu.RegisterCard();
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Are you sure you want to exit [y/n]?");
                            char choice = Convert.ToChar(Console.ReadLine());
                            isTrue = choice == 'y' ? false : true;

                        }
                        break;
                    default:
                        {
                            Console.Clear();
                        } break;
                }
            }
        }
	    

	
    }
}