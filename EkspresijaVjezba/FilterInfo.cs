using System;
using System.Collections.Generic;
using System.Text;

namespace EkspresijaVjezba
{
    public class FilterInfo
    {
        public string Condition { get; set; }
        public List<RulesInfo> Rules { get; set; } = new List<RulesInfo>();
    }
}
