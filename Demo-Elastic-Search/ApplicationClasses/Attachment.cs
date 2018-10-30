using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses
{
    public class Attachment : Base
    {
        public string Filename { get; set; }
        public string Content { get; set; }
        public string Additional_teamName { get; set; }
        public string Additional_mailCommentId { get; set; }
        public double Additional_fileSize { get; set; }
        public string Additional_fileUrl { get; set; }
        public string Additional_shortenUrl { get; set; }
    }
}
