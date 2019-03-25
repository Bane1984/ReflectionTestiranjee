using System;
using System.Collections.Generic;
using System.Text;

namespace EkspresijaVjezba
{
    public class QueryInfo
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public List<SortInfo> Sorters { get; set; } = new List<SortInfo>();
        public FilterInfo Filter { get; set; }
    }
}
