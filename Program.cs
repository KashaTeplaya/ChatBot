using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatBot
{
    class Program
    {
        static void bot_GetStr(string obj) { Console.WriteLine(obj); }
        static void Main(string[] args)
        {
            ChatBot bot = new ChatBot(@"C:\Users\Bacha\Desktop\1.txt");
            bot.GetStr += bot_GetStr;

            while (true) 
            {
                string q = Console.ReadLine();
                bot.Ans(q);
            }
        }
        
    }
}
