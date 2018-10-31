using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses.OutputClasses
{
    public class VideoAc : BaseAc
    {
        public string Address { get; set; }
        public string Notes { get; set; }
        public string Content { get; set; }
        public string MediaType { get; set; }
        public string AudioUrl { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string VideoThumbNailUrl { get; set; }
        public string ShortenUrl { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }
        public string Size { get; set; }
        public string Duration { get; set; }
        public string MediaLatitude { get; set; }
        public string MediaLongtitude { get; set; }
        public string MediaLocation { get; set; }
        public string MediaBreadCrumb { get; set; }
        public List<UsedIn> UsedIn { get; set; }
    }
}
