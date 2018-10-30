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
        public string ReportGeneratedBy { get; set; }

        public string AdditionalFromUserId { get; set; }
        public string AdditionalReportGeneratedById { get; set; }        
    }
}
