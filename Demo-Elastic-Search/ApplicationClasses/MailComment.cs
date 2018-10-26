using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses
{
    public class MailComment : Base
    {
        public string Message { get; set; }
        public string FromEmail { get; set; }
        public string[] CC { get; set; }
        public string[] Attachments { get; set; }
        public string Subject { get; set; }

        public string Additional_teamName { get; set; }
        public string Additional_fromUserId { get; set; }
        public string Additional_reportGeneratedById { get; set; }
        public string Additional_reportGeneratedBy { get; set; }
    }
}
