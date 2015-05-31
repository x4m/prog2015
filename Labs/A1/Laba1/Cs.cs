using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    public class Cs
    {
        

        public int Power { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public Aura Type { get; set; }

  
    }

    public enum Aura
    {
        green,
        dark,
        blue,
        orange,
        white,
        gold
    }
}
