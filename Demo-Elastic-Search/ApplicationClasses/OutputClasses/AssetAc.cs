using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses.OutputClasses
{
    public class AssetAc : BaseAc
    {
        public string Title { get; set; }
        public List<string> Data { get; set; }
        public List<string> Columns { get; set; }
        public List<FieldsInJson> FieldsInJson { get; set; }
        public string Teamname { get; set; }
        public string FormId { get; set; }
        public string FormTitle { get; set; }
        public string FormCreatedById { get; set; }
        public string FormCreatedBy { get; set; }
        public string FormUpdatedId { get; set; }
        public string FormUpdatedBy { get; set; }
        public string FormCreatedDateTime { get; set; }
        public string FormUpdatedDateTime { get; set; }
    }
}
