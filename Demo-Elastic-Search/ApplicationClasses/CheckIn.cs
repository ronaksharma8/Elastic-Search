using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses
{
    public class CheckIn : Base
    {
        public string Address { get; set; }
        public string AdditionalTeamName { get; set; }
        public string AdditionalLatitude { get; set; }
        public string AdditionalLongitude { get; set; }
    }
}
