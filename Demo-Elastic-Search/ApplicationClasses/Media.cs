using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses
{
    public class Media : Base
    {
        public string Address { get; set; }
        public string Notes { get; set; }
        public string Content { get; set; }
        public string AdditionalMediaType { get; set; }
        public string AdditionalAudioUrl { get; set; }
        public string AdditionalImageUrl { get; set; }
        public string AdditionalVideoUrl { get; set; }
        public string AdditionalVideoThumbNailUrl { get; set; }
        public string AdditionalShortenUrl { get; set; }
        public string AdditionalLatitude { get; set; }
        public string AdditionalLongtitude { get; set; }
        public string AdditionalSize { get; set; }
        public string AdditionalDuration { get; set; }
        public string AdditionalMediaLatitude { get; set; }
        public string AdditionalMediaLongtitude { get; set; }
        public string AdditionalMediaLocation { get; set; }
        public string AdditionalMediaBreadCrumb { get; set; }
    }
}
