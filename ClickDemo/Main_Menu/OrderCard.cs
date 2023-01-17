using ClickDemo.Cards;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ClickDemo.Main_Menu
{
    public class OrderCard
    {
        const string FileUz = @"C:\Users\Asus\Documents\Text\OrderCard.txt";
        List <string> OrderedList = File.ReadAllLines(FileUz).ToList();

        public static void GetCardOreder()
        {
            bool isActive = true;
            
            while (isActive)
            {
                Console.Clear();
                Console.Write("1.UzCard\n2.Humo\n3.MasterCard\n4.Visa\n0.Back\nChoose option: ");
                int i = int.Parse(Console.ReadLine());
                switch(i)
                {
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            UzCard.GetUzCard();
                        }
                        break;
                    case 2:
                        {
                            Humo.GetHumo();
                        }
                        break;
                    case 3:
                        {
                            MasterCard.GetMasterCard();
                        }
                        break;
                    case 4:
                        {
                            Visa.GetVisa();
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
        private string _fullname;
        private string _number;
        private string _adress;
        private string _passport;
        public string FullName
        {
            get { return _fullname; }
            set { _fullname = value; }
        }
        public string PhoneNumber
        {
            get { return _number; }
            set { _number = value; }    
        }
        public string Adress
        {
            get { return _adress; }
            set
            {
                _adress = value;
            }
        }
        public string Passport
        {
            get { return _passport; }
            set
            {
                _passport = value;
            }
        }

        static OrderCard Order = new OrderCard();

        public void AddToText()
        {
            OrderedList.Add(FullName);
            OrderedList.Add(PhoneNumber);
            OrderedList.Add(Adress);
            OrderedList.Add(Passport);

            File.WriteAllLines(FullName, OrderedList);

            Console.Write("Succesfully Ordered\nPress any key to continue...");
            Console.ReadKey();
            return;
        }
        public static void GetCardInfo() 
        {
            

            Console.Write("Full Name: ");
                Order.FullName = Console.ReadLine();
                Console.Write("Phone Number: +(998) ");
                Order.PhoneNumber = Console.ReadLine();
                Console.Write("Adress: ");
                Order.Adress = Console.ReadLine();
                Console.Write("Passport number: ");
                Order.Passport = Console.ReadLine();
                Order.AddToText();

           
        }
    }
}
