using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport
{
    public class PassportData
    {
        public PassportData()
        {
            Employments = new List<EmploymentData>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }

        public Gender Gender { get; set; }

        public List<EmploymentData> Employments { get; set; }

        public byte[] Photo { get; set; }
    }

    public class EmploymentData
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("С: {0}, По: {1}, Место: {2}, Адрес: {3}", Start, End, Name, Address);
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
