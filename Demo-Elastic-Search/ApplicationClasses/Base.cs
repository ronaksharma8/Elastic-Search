using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses
{
    public class Base
    {
        public string Type { get; set; }

        public string AdditionalId { get; set; }
        public string AdditionalJobId { get; set; }
        public string AdditionalJobTitle { get; set; }
        public string AdditionalJobDescription { get; set; }
        public string AdditionalJobAddress { get; set; }
        public string AdditionalJobUpdatedBy { get; set; }
        public DateTime AdditionalJobUpdatedDateTime { get; set; }
        public DateTime AdditionalJobCreatedDateTime { get; set; }

        public string AdditionalTeamName { get; set; }
        public string AdditionalTeamId { get; set; }
        public string AdditionalTeamIcon { get; set; }
        public DateTime AdditionalTeamCreatedDateTime { get; set; }
        public DateTime AdditionalTeamUpdatedDateTime { get; set; }


        public string AdditionalCreatedById { get; set; }
        public string AdditionalCreatedBy { get; set; }
        public string AdditionalUpdatedById { get; set; }
        public string AdditionalUpdatedBy { get; set; }
        public DateTime AdditionalCreatedDateTime { get; set; }
        public DateTime AdditionalUpdatedDateTime { get; set; }
    }
}
