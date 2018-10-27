using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses
{
    public class Base
    {
        public string Type { get; set; }

        // particular entity id
        public string Additional_id { get; set; }
        
        public string Additional_jobId { get; set; }
        public string Additional_jobTitle { get; set; }
        public string Additional_jobCreatedDateTime { get; set; }
        public string Additional_jobUpdateDateTime { get; set; }

        public string Additional_teamId { get; set; }
        public string Additional_teamIcon { get; set; }
        public string Additional_teamCreatedDateTime { get; set; }
        public string Additional_teamUpdateDateTime { get; set; }

        // particular entity related..
        public string Additional_createdById { get; set; }
        public string Additional_createdBy { get; set; }
        public string Additional_updatedById { get; set; }
        public string Additional_updatedBy { get; set; }
        public DateTime Additional_createdDateTime { get; set; }
        public DateTime Additional_updatedDateTime { get; set; }
    }
}
