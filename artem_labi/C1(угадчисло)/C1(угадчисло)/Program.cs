using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1_угадчисло_
{
    class Program
    {
        static int maxchislo = 101;
        static int minchislo = 0;
        static int srednee = ((maxchislo + minchislo)/2);
        static bool otgadano = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Загадайте число от 0 до 100 (Чтобы подтвердить пишите yes)");
            while (!otgadano)
            {
                Console.WriteLine("Ваше число меньше " + srednee + "?");
                if (Console.ReadLine().ToLower() == "yes")
                    maxchislo = srednee;
                else 
                    minchislo = srednee;
                srednee = ((maxchislo + minchislo) / 2);
                if (srednee == minchislo)
                    break;
            }
                
               Console.WriteLine("Вы загадывли число " + minchislo + "!");
               Console.ReadKey();
          }
        }
    }

