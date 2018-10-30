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
        public string TeamName { get; set; }
        public string AdditionalFormId { get; set; }
        public string AdditionalFormTitle { get; set; }
        public string AdditionalFormCreatedById { get; set; }
        public string AdditionalFormCreatedBy { get; set; }
        public string AdditionalFormUpdatedId { get; set; }
        public string AdditionalFormUpdatedBy { get; set; }
        public DateTime AdditionalFormCreatedDateTime { get; set; }
        public DateTime AdditionalFormUpdatedDateTime { get; set; }
    }
}
