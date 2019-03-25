using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace EkspresijaVjezba
{
    public class RulesInfo
    {
        public string Property { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; } //za sada je string, kasnije upotrijebiti - posle odredjivanja tipa preko refleksije, konvertovanje u drugi tip
    }
}
