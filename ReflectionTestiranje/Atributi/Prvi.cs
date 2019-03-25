using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectionTestiranje.Atributi
{
    public class Prvi:Attribute
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Godine;

        public void Provjera()
        {

        }
    }
}
