using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses
{
    public class JobPage : Base
    {
        public string Title { get; set; }
        public string[] TabNames { get; set; }
        public string[] SectionNames { get; set; }
        public string[] PropertyNames { get; set; }
        public string[] FieldPlaceholders { get; set; }
        public string[] Fields { get; set; }
        public List<FieldsInJson> FieldsInJson { get; set; }
        public string TeamName { get; set; }
        public string Formtype { get; set; }
    }

    public class FieldsInJson
    {
        public string Tab { get; set; }
        public string Section { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
    }
}
