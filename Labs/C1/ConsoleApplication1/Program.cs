using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 min = 0, max = 10000, sredn;
            sredn = ((min + max) / 2);
            while (true)
            {
                Console.WriteLine("Ваше число меньше " + sredn + "?");
                if (Console.ReadLine()[0] == 'y')
                    max = sredn;
                else
                    min = sredn;
                sredn = ((min + max) / 2);
                if (sredn == min)
                {
                    break;
                }
            }
            Console.WriteLine("Это число " + min + "?");
            if (Console.ReadLine()[0] == 'y')
            {
                Console.WriteLine("Ура, я угадал!");
            }
            else
            {
                Console.WriteLine("Пичалька :с");
            }
            Console.ReadKey();
        }
    }
}
