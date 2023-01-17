using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Policy;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ClickDemo
{
    public class SiginUp
    {
        const string FilePath = @"C:\Users\Asus\Documents\Text\DataBase.txt";
        //List<string> NumbersOfId = File.ReadAllLines(FilePath).ToList();
        static List<string> Names = File.ReadAllLines(FilePath).ToList();
        Random random = new Random();

        private int _id;
        private bool isActive = true;
        private string _name;
        private string _last;

        static public bool IsCorrect { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (_name != null)
                    Names.Add($"Name : {_name.ToUpper()}");
                else
                    GetInfo();
            }
        }

        public string Last
        {
            get { return _last; }
            set
            {
                _last = value;
                if (_last != null)
                    Names.Add($"Last : {_last.ToUpper()}");
                else
                    GetInfo();
            }
        }
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                if (_age > 15)
                    Names.Add($"Age : {_age}");
            }
        }

        private string pro;
        public int Id
        {
            get
            {
                while (isActive)
                {
                    _id = random.Next(1, 50);
                    pro = $"Id : {_id.ToString()}";
                    if (!Names.Contains(pro))
                    {
                        Names.Add($"Id : {_id}");
                        isActive = false;
                    }
                }
                return _id;
            }
        }
        private string _password;

        public string Pass 
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }
        static void AddToText()
        {
            Console.Write("You must remind Your id and password!\nPress any key to continue...");
            Console.ReadKey();
            Names.Add("------------------");
            File.WriteAllLines(FilePath, Names);
            return;
        }
        private string _test;
        public string Test
        {
            get { return _test; }
            set { _test = value; }
        }

        /// <summary>
        /// Get person Information
        /// </summary>

        public static void GetInfo()
        {

            bool isTrue = true;
            Console.Clear();
            SiginUp person = new SiginUp();
            
            Console.Write("0.Back\nName: ");
            person.Name = Console.ReadLine();
            if (person.Name == "0") { return; }
            Console.Write("Last: ");
            person.Last = Console.ReadLine();
            if (person.Last == "0") { return; }
            Console.Write("Age: ");
            person.Age = int.Parse(Console.ReadLine());
            if (person.Age > 15)
            {
                Console.WriteLine($"Your ID is: {person.Id}");
                int count = 0;
                while (isTrue)
                {
                    if (count == 3)
                    {
                        Names.Clear();
                        Console.Clear();
                        Console.WriteLine("incorrect! please try again!");
                        isTrue = false;
                        IsCorrect = false;
                        GetInfo();
                        
                    }
                    
                    Console.Write("Create a password: ");
                    person.Pass = Console.ReadLine();
                    Console.Write("Confirm password: ");
                    person.Test = Console.ReadLine();
                    if (person.Test == person.Pass)
                    {
                        Names.Add($"Password : {person.Test}");
                        IsCorrect = true;
                        isTrue = false;
                        AddToText();
                        return;
                        //person._password = person.Pass;
                    }
                    else
                    {
                        count++;
                        Console.WriteLine("Cant Confirm!");
                    }
                }
            }
            else if (person.Age == 0) return;

            else
            {
                IsCorrect = false;
                Console.Write("Your age is under 16\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
            
        }   
    }
}