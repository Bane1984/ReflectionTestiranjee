using System;
using System.Collections.Generic;
using System.Text;

namespace EkspresijaVjezba
{
    public class Entitet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}
