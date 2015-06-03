using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Contacts
{
   public class ClassContacts
    {
        public string Dcompany { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }

        public DateTime LastCall { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public bool  Checked  { get; set; }

    }
    
}
