using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace C1
{
    internal class Program
    {
        //private static int c;

        private static void Main(string[] args)
        {
            int k = 512;
            Console.WriteLine(
                "Здравствуйте, я искусственный интеллект способный отгадать задуманное число, но для этого вам будет нужно ответить на мои вопросы. Итак начнем, загадайте число от 1 до " +
                k+" \nотвечайте на вопросы словами да или нет и никакими иначе :)");
            int a, b = k/2, c = k;
            string o;
            for (int i = 1; i <= 8; i++)
            {
                Console.WriteLine("Это число больше " + b + " ?");
                o = Console.ReadLine();
                if (o == "да")
                {
                    c = c/2;
                    b = b + c/2;

                }
                else
                {
                    c = c/2;
                    b = b - c/2;
                }
            }
            
                Console.WriteLine("Это число больше " + b + " ?");
                o = Console.ReadLine();
                if (o == "да")

                    b = b + 1;
 
            Console.WriteLine("Ваше число " + b);
            Console.ReadKey();
        }
    }
}
