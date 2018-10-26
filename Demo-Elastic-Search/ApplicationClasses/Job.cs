using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses
{
    public class Job : Base
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string TeamName { get; set; }
        public string JobStatus { get; set; }
        public string[] Contributors { get; set; }
        public string[] Viewers { get; set; }
        public string[] Inspectors { get; set; }        
        public List<object> Overview { get; set; }
        public List<object> Conclusion { get; set; }
        public List<MailComment> MailComments { get; set; }
        public List<object> CheckIn { get; set; }
    }
}
