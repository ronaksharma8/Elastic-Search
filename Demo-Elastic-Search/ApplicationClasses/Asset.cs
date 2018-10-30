using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses
{
    class Asset : Base
    {        
        public string Title { get; set; }
        public List<string> Data { get; set; }
        public List<string> Columns { get; set; }
        public List<FieldsInJson> FieldsInJson { get; set; }
        public string Teamname { get; set; }        
        public string Additional_formId { get; set; }
        public string Additional_formTitle { get; set; }
        public string Additional_formCreatedById { get; set; }
        public string Additional_formCreatedBy { get; set; }
        public string Additional_formUpdatedId { get; set; }
        public string Additional_formUpdatedBy { get; set; }
        public string Additional_formCreatedDateTime { get; set; }
        public string Additional_formUpdatedDateTime { get; set; }
    }
}
