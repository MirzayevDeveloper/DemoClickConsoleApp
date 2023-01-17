using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ClickDemo.Main_Menu;

namespace ClickDemo
{
    class Program
    {
        static void FirstMenu()
        {
            
            while (true)
            {
                Console.Clear();
                Console.Write("1.Add Card\n2.Order Card\n3.Log out\nChoose option: ");
                int choice = int.Parse(Console.ReadLine());
                switch(choice) 
                {
                    case 1:
                        {
                            Console.Clear();
                            MainMenu.RegisterCard();
                            return;
                        }
                        //break;
                    case 2:
                        {
                            OrderCard.GetCardOreder();
                            return;
                        }
                    case 3:
                        {
                            return;
                        }
                    default:
                        {
                            Console.Clear();
                        }break;
                }
            }
        }
        static void Main(string[] args)
        {
            string locate = @"C:\Users\Asus\Documents\Text\Balance.txt";
            string Path = @"C:\Users\Asus\Documents\Text\DataBase.txt";
            string pinLock = @"C:\Users\Asus\Documents\Text\CardList.txt";
            string _balance = "";
            bool isActive = true;

            bool isHave = false;

            while (isActive)
            {

                Console.Clear();
                Console.Write("1.Sign in\n2.Sign up\n3.Exit\n\nChoose Option: ");
                int i = int.Parse(Console.ReadLine());
                switch(i)
                {
                    case 1:
                        {
                            Console.Clear();
                            SiginIn.GetLoginInfo();
                            
                            if (SiginIn.Correct)
                            {
                                List<string> DataBase = File.ReadAllLines(Path).ToList();
                                List<string> BalanceList = File.ReadAllLines(locate).ToList();
                                List<string> PassList = File.ReadAllLines(pinLock).ToList();

                                if (PassList.Count > 0)
                                {
                                    int index = DataBase.IndexOf(PassList.ElementAt(0));
                                    _balance = DataBase[index + 1];
                                    if (_balance != null)
                                        isHave = true;
                                }

                                string numbers = "";
                                if (isHave)
                                {
                                    for (int l = 0; l < _balance.Length; l++)
                                    {
                                        if (Char.IsDigit(_balance[l]))
                                            numbers += _balance[l];
                                    }
                                    if (numbers.Length > 0 && Char.IsDigit(numbers, 2))
                                    {
                                        OldMenu.SecondMenu();
                                    }
                                    else
                                        FirstMenu();
                                }
                            }
                            else
                            {
                                if (SiginIn.Correct)
                                    OldMenu.SecondMenu();
                            }
                        }
                        break;
                    case 2:
                        { 
                            Console.Clear(); 
                            SiginUp.GetInfo();
                            if (SiginUp.IsCorrect)
                            {
                                isActive = true;
                            }
                        }
                        break;
                    case 3:
                        { isActive = false; }
                        break;

                    default:
                        { Console.Clear(); }
                        break;

                }
                
            }
        }
    }
}
