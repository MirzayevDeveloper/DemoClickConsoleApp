using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace ClickDemo
{
    public class MainMenu
    {
        const string FilePath = @"C:\Users\Asus\Documents\Text\DataBase.txt";
        const string location = @"C:\Users\Asus\Documents\Text\CardList.txt";
        //public const string filepath = @"C:\Users\Asus\Documents\Text\CardList.txt";
        static List <string> CardList = File.ReadAllLines(FilePath).ToList();
        static List<string> PassList = File.ReadAllLines(location).ToList();
        static Random random = new Random();

        private string _card;
        private string _phone;
        private string _validate;
        private string _answer;
        private double _balance;

        public string Validated
        {
            get { return _answer; }
            set { _answer = value; }
        }

        public string Validation
        {
            get { return _validate; }
            set { _validate = value; }
        }
        public string CardNumber
        {
            get { return _card; }
            set { _card = value; }
        }
        public string PhoneNumber
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        static void AddToText()
        {

            File.WriteAllLines(FilePath, CardList);
            File.WriteAllLines(location, PassList);
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            
        }
        static MainMenu first = new MainMenu();
        public static void RegisterCard()
        {
            bool isActice = true;
            bool isTrue = true;
            int count = 0;
            int number = 0;
            
            while (isTrue)
            {
                Console.Clear();
                if(count == 3)
                {
                    Console.Write("Error occurred please try again later\nPress any key to continue...");
                    Console.ReadKey();
                    return;
                }
                Console.Write("0.Back\nEnter card number: ");
                first.CardNumber = Console.ReadLine();
                if (first.CardNumber == "0") return;
                Console.Write("Enter Phone Number: +(998) ");
                first.PhoneNumber = Console.ReadLine();
                if(first.PhoneNumber == "0") return;
                else if(first.CardNumber.Length == 16 && first.PhoneNumber.Length == 9) 
                {
                    while(isActice)
                    {
                        Console.Clear();
                        if(number == 3)
                        {
                            Console.Write("You cant validate please try again!\nPress any key to continue...");
                            Console.ReadKey();
                            return;
                        }
                        first.Validated = random.Next(10000, 1000000).ToString();
                        Console.WriteLine($"0.Back\nis it: {first.Validated}");
                       // DateTime TimeStop = DateTime.Now.AddSeconds(8);
                       
                        Console.Write("Validation: ");
                        first.Validation = Console.ReadLine();
                        if (first.Validation == "0") return;
                        else if (first.Validation == first.Validated)
                        {
                            isActice = false;
                            const int h = 0;
                            if(PassList.Count > 0)
                            {
                                int index = CardList.IndexOf(PassList[h]);
                                CardList.Insert(index + 1, $"Balance : {first.Balance = 1000000.0}");
                                CardList.Insert(index + 2, $"Card Number : {first.CardNumber}");
                                CardList.Insert(index + 3, $"Phone Number : +(998) {first.PhoneNumber}");
                                isTrue = false;
                                AddToText();
                                OldMenu.SecondMenu();
                            }
                            //int index = CardList.FindIndex(a => a.Contains(PassList[h]));

                        }
                        else
                        {
                            number++;
                        }
                    }
                }
                else
                {
                    count++;
                    Console.Write($"Card number or phone number is incorrect! {count}\nPress any key to continue...");
                    Console.ReadKey();
                }
                
            }
        }

        
    }
}