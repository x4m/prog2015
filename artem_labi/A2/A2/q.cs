using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws
{
    public class klub
    {
        public klub()
        {
            clubs = new List<Add>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Combo { get; set; }
        public string Combo2 { get; set; }

        public DateTime Date { get; set; }
        public List<Add> clubs { get; set; }
    }

    public class Add
    {
        public string Combo3 { get; set; }
        public string Team { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public override string ToString()
        {
            return string.Format("Играл в лиге: {0}, В команде:  {1}, С: {2}, По: {3}", Combo3, Team, Start, End);
        }
    }
}


