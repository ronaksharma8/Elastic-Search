using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Elastic_Search.ApplicationClasses.OutputClasses
{
    public class FormAc : BaseAc
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] TabNames { get; set; }
        public string[] SectionNames { get; set; }
        public string[] PropertyNames { get; set; }
        public string[] FieldPlaceholders { get; set; }
        public string TeamName { get; set; }
        public string FormType { get; set; }
        public string FormScope { get; set; }
        public string Icon { get; set; }
    }
}
