using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace ClickDemo
{
    public class SiginIn
    {
        const string location = @"C:\Users\Asus\Documents\Text\CardList.txt";
        const string FilePath = @"C:\Users\Asus\Documents\Text\DataBase.txt";
        static List <string> CheckLogin = File.ReadAllLines(FilePath).ToList();
        
        private int _id;
        private string _password;
        static SiginIn user = new SiginIn();
        static public bool Correct
        {
            get;
            set;
        }
        public int GetId
        {
            get { return _id; }
            set { _id = value; }
        }
        public string GetPass
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _test;
        public string Test
        {
            get { return _test; }
            set { _test = value; }
        }

        static void Return()
        {
            Correct = false;
            Console.WriteLine("Your Password or Id is incorrect please try again!\nPress any key to continue...");
            Console.ReadKey();
            
            return;
        }
        public static void GetLoginInfo()
        {
            
            Console.Write("Enter your id: ");
            user.GetId = int.Parse(Console.ReadLine());
            if(user.GetId == 0) { return; }
            Console.Write("Enter your password: ");
            user.GetPass = Console.ReadLine();
            if (user.GetPass == "0") { return; }
            user.Test = $"Id : {user.GetId.ToString()}";
            if (CheckLogin.Contains(user.Test))
            {
                user.Test = $"Password : {user.GetPass}";
                if (CheckLogin.Contains(user.Test))
                {
                    List<string> PassList = File.ReadAllLines(location).ToList();
                    PassList.Clear();
                    PassList.Add(user.Test);
                    Correct = true;
                    File.WriteAllLines(location, PassList);
                    
                }
                else
                    Return();
            }
            else
                Return();

        }
    }
}