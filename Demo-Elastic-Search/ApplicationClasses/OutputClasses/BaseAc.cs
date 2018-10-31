using Demo_Elastic_Search.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses.OutputClasses
{
    public class BaseAc
    {
        public string Type { get; set; }

        // particular entity id
        public string Id { get; set; }

        public string JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobAddress { get; set; }
        public string JobUpdatedBy { get; set; }

        public string JobCreatedDateTime { get; set; }
        public string JobUpdatedDateTime { get; set; }

        public string TeamId { get; set; }
        public string TeamIcon { get; set; }
        public string TeamCreatedDateTime { get; set; }
        public string TeamUpdateDateTime { get; set; }

        // particular entity related..
        public string CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedById { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedDateTime { get; set; }
        public string UpdatedDateTime { get; set; }
    }

    public class UsedIn
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public List<dynamic> Entity { get; set; }
    }
}
