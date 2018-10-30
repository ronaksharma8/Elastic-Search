using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses
{
    public class Attachment : Base
    {
        public string Filename { get; set; }
        public string Content { get; set; }        
        public string AdditionalMailCommentId { get; set; }
        public double AdditionalFileSize { get; set; }
        public string AdditionalFileUrl { get; set; }
        public string AdditionalShortenUrl { get; set; }
    }
}
