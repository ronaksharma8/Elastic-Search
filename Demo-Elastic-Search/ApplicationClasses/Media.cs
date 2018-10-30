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
        public string Additional_mediaType { get; set; }
        public string Additional_audioUrl { get; set; }
        public string Additional_imageUrl { get; set; }
        public string Additional_videoUrl { get; set; }
        public string Additional_videoThumbNailUrl { get; set; }
        public string Additional_shortenUrl { get; set; }
        public string Additional_latitude { get; set; }
        public string Additional_longtitude { get; set; }
        public string Additional_size { get; set; }
        public string Additional_duration { get; set; }
        public string Additional_mediaLatitude { get; set; }
        public string Additional_mediaLongtitude { get; set; }
        public string Additional_mediaLocation { get; set; }
        public string Additional_mediaBreadCrumb { get; set; }
    }
}
