using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace ClickDemo.Main_Menu
{
    public class History
    {
        public static void CheckHistory()
        {
            Console.Clear();

            const string location = @"C:\Users\Asus\Documents\Text\CardList.txt";
            const string HistoryPath = @"C:\Users\Asus\Documents\Text\History.txt";
            List<string> PassList = File.ReadAllLines(location).ToList();
            List<string> history = File.ReadAllLines(HistoryPath).ToList();
            int i = history.FindIndex(a => a.Contains(PassList[0]));
            
            if (history.Count > 0)
            {
                for (int j = i; j < i + 5; j++)
                {
                    Console.WriteLine(history[j]);
                }
                PassList.Clear();
                File.WriteAllLines(location, PassList);
                Console.WriteLine("Press any key to continu...");
                Console.ReadKey();
                
            }
            else
                return;
            
        }

    }
}
