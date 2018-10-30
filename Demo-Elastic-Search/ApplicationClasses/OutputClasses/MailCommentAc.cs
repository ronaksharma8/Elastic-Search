using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses.OutputClasses
{
    public class MailCommentAc : BaseAc
    {
        public string Message { get; set; }
        public string FromEmail { get; set; }
        public string[] CC { get; set; }
        public string[] Attachments { get; set; }
        public string Subject { get; set; }

        public string TeamName { get; set; }
        public string FromUserId { get; set; }
        public string ReportGeneratedById { get; set; }
        public string ReportGeneratedBy { get; set; }
        public List<UsedIn> UsedIn { get; set; }
    }
}
