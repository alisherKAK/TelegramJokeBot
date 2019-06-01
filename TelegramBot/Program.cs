using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            TelegramBot bot = new TelegramBot();

            bot.Open();
            Console.ReadLine();
            bot.Close();
        }
    }
}
