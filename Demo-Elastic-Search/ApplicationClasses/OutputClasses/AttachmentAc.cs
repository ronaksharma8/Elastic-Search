using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses.OutputClasses
{
    public class AttachmentAc : BaseAc
    {
        public string Filename { get; set; }
        public string Content { get; set; }
        public string TeamName { get; set; }
        public string MailCommentId { get; set; }
        public double FileSize { get; set; }
        public string FileUrl { get; set; }
        public string ShortenUrl { get; set; }
    }
}
