using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses
{
    public class CheckIn : Base
    {
        public string Address { get; set; }
        public string Additional_teamName { get; set; }
        public string Additional_lat { get; set; }
        public string Additional_long { get; set; }
    }
}
