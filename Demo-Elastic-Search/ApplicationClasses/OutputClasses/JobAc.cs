using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses.OutputClasses
{
    public class JobAc : BaseAc
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string TeamName { get; set; }
        public string JobStatus { get; set; }
        public string[] Contributors { get; set; }
        public string[] Viewers { get; set; }
        public string[] Inspectors { get; set; }      
        public List<UsedIn> UsedIn { get; set; }
    }
}
