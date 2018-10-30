using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses.OutputClasses
{
    public class CheckInAc : BaseAc
    {
        public string Address { get; set; }
        public string TeamName { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}
