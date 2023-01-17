using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Data;
using System.Security.Cryptography;

namespace ClickDemo.Main_Menu
{
    public class Transfer
    {
        const string BalancePath = @"C:\Users\Asus\Documents\Text\Balance.txt";
        const string HistoryPath = @"C:\Users\Asus\Documents\Text\History.txt";
        const string FilePath = @"C:\Users\Asus\Documents\Text\DataBase.txt";
        const string location = @"C:\Users\Asus\Documents\Text\CardList.txt";
        static List<string> DataBase = File.ReadAllLines(FilePath).ToList();
        static List<string> PassList = File.ReadAllLines(location).ToList();
        static public List<string> BalanceList = File.ReadAllLines(BalancePath).ToList();
        static List<string> History = File.ReadAllLines(HistoryPath).ToList();

        static public int UserPassword = DataBase.FindIndex(a => a.Contains(PassList[0]));
        static string BalanceInString = DataBase[UserPassword+1];
        private  double _balance;
        private string numbers;
        private  string _password = DataBase[UserPassword];
        public static string GetPin { get { return me._password; } }

        static Transfer me = new Transfer();
        
        public void BalanceToDouble()
        {
            for (int i = 0; i < BalanceInString.Length; i++)
            {
                if (char.IsDigit(BalanceInString[i]))
                {
                    numbers += BalanceInString[i];
                }
            }
            Balance = Convert.ToDouble(numbers);
            BalanceList.Add(Balance.ToString());
            File.WriteAllLines(BalancePath, BalanceList);
            BalanceList.Clear();
        }

        public static double Balance
        {
            get { return me._balance; }
            set { me._balance = value; }
        }

        private string _card;
        private double _amount;
        public string RecieverCard
        {
            get { return _card; }
            set { _card = value; }
        }
        public double Amount
        {
            get { return _amount; } 
            set { _amount = value; }
        }
        private DateTime _date = DateTime.Now;
        public string GetDate
        {
            get { return _date.ToString(); }
            
        }
        private void AddTotext()
        {
            DataBase.RemoveAt(UserPassword + 1);
            DataBase.Insert(UserPassword + 1, $"Balance : {Balance}");
            History.Add($"Sender : {GetPin}");
            History.Add($"Reciever card : {RecieverCard}");
            History.Add($"Amount : {Amount}");
            History.Add($"Data Time : {GetDate}");
            History.Add("--------------------");
            File.WriteAllLines(FilePath, DataBase);
            File.WriteAllLines(HistoryPath, History);
        }
        public static void Transaction()
        {
            
            me.BalanceToDouble();
            int count = 0;
            while (true)
            {
                Console.Clear();
                if(count == 3)
                {
                    Console.WriteLine("Error occurred please try again later\nPress any key to continue...");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Reciever card number: ");
                me.RecieverCard = Console.ReadLine();
                if(me.RecieverCard.Length == 16)
                {
                    Console.Write("Amount of transaction: ");
                    me.Amount = Convert.ToDouble(Console.ReadLine());
                    if(me.Amount < Balance)
                    {
                        Balance -= me.Amount;
                        me.AddTotext();

                        Console.Write("Succesfull\nPress any key to continue...");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("You hava not enough money!");
                        count++;
                    }
                }
                
            }
        }

    }
}
