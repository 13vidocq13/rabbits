using System;
using System.Collections.Generic;
using Entities;

namespace Contract
{
    public class Filters
    {
        public string FemaleName { get; set; }
        public string MaleName { get; set; }
        public IList<Results> Results { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
