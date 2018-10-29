using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using Demo_Elastic_Search.ApplicationClasses;
using System.Collections;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Demo_Elastic_Search
{
    public class ElasticSearch1
    {
        public static void TestMethod()
        {
            var connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
                                     .DefaultIndex("forms")
                                     .DefaultMappingFor<ApplicationClasses.Job>(i => i.IdProperty("additional_id"))
                                     .DefaultMappingFor<Form>(i => i.IdProperty("additional_id"))
                                     .DefaultMappingFor<MailComment>(i => i.IdProperty("additional_id"))
                                     .PrettyJson()
                                     .RequestTimeout(TimeSpan.FromMinutes(2));

            var client = new ElasticClient(connectionSettings);
            //CreateJobIndexMapping(client);
            //CreateFormIndexMapping(client);
            //CreateMailCommentIndexMapping(client);

            var mailComment = new MailComment()
            {
                Type = "Mail comments",
                Message = "mail message 1",
                FromEmail = "abc1@mailinator.com",
                CC = new string[] { "abc1@mailinator.com", "abc2@mailinator.com" },
                Attachments = new string[] { "File1.xlz", "File_Image.xlxs" },
                Subject = "Subject for the mail coment will be ",
                Additional_id = "16f71517-1124-43b7-bebe-6387999a87bd",
                Additional_jobId = "16f71517-1124-43b7-bebe-6387999a87bd",
                Additional_jobTitle = "Job Title",
                Additional_teamId = "16f71517-1124-43b7-bebe-6387999a87bd",
                Additional_teamName = "Corpac",
                Additional_teamIcon = "https://devapps.visualogyx.com/team-icon.png",
                Additional_fromUserId = "abc1@mailinator.com",
                Additional_reportGeneratedById = "16f71517-1124-43b7-bebe-6387999a87bd",
                Additional_reportGeneratedBy = "ABC",
                Additional_createdDateTime = DateTime.Now,
                Additional_updatedDateTime = DateTime.Now
            };

            var resMailComment = client.Index(mailComment, i => i
                       .Index("mailcomments2")
                       .Type("mailcomment"));

            // code for job addition..
            var job = new ApplicationClasses.Job()
            {
                Type = "Job",
                Title = "Job 1",
                Description = "Test Job Description",
                Address = "E 90 Saujanya Society Opp Bhavan School",
                TeamName = "Corpac",
                JobStatus = "inprogress",
                Contributors = new string[] { "abc", "asd" },
                Viewers = new string[] { "abc", "asd" },
                Inspectors = new string[] { "abc", "asd" },
                Additional_teamId = "16f71517-1124-43b7-bebe-6387999a87bd",
                Additional_teamIcon = "https://devapps.visualogyx.com/team-icon.png",
                Additional_id = "16f71517-1124-43b7-bebe-6387999a87bd",
                Additional_createdById = "16f71517-1124-43b7-bebe-6387999a87bd",
                Additional_createdBy = "ABC",
                Additional_updatedById = "16f71517-1124-43b7-bebe-6387999a87bd",
                Additional_updatedBy = "XYZ",
                Additional_createdDateTime = DateTime.Now,
                Additional_updatedDateTime = DateTime.Now
            };

            var resJob = client.Index(job, i => i
                       .Index("jobs2")
                       .Type("job"));

            // code for form addition..
            var form = new Form()
            {
                Type = "Job",
                Title = "Job 1",
                Description = "Test Job Description",
                TeamName = "Corpac",
                TabNames = new string[] { "prop1", "prop2" },
                SectionNames = new string[] { "prop1", "prop2" },
                PropertyNames = new string[] { "prop1", "prop2" },
                FieldPlaceholders = new string[] { "prop1", "prop2" },
                FormType = "UserForm",
                FormScope = "Public",
                Additonal_icon = "https://devapps.visualogyx.com/team-icon.png",
                Additional_id = "16f71517-1124-43b7-bebe-6387999a87bF",
                Additional_teamId = "16f71517-1124-43b7-bebe-6387999a87bd",
                Additional_teamIcon = "https://devapps.visualogyx.com/team-icon.png",
                Additional_createdById = "16f71517-1124-43b7-bebe-6387999a87bd",
                Additional_createdBy = "ABC",
                Additional_updatedById = "16f71517-1124-43b7-bebe-6387999a87bd",
                Additional_updatedBy = "XYZ",
                Additional_createdDateTime = DateTime.Now,
                Additional_updatedDateTime = DateTime.Now
            };

            var resForm = client.Index(form, i => i
                       .Index("forms2")
                       .Type("form"));

            // code for search..
            string search = "test";
            var resSearch = client.Search<dynamic>(s => s
                    .AllIndices()
                    .AllTypes().Size(10)
                    .Query(q => q
                        .QueryString(qs => qs.Query(search))));

            if (resSearch.Hits.Count > 0)
            {
                var returnObj = new { Time = string.Format("{0} {1}", resSearch.Took, " ms"), Document = resSearch.Hits, Count = resSearch.Total };
            }

            // code to give json output to mobile end..
            ArrayList lstObject = new ArrayList();
            foreach (var doc in resSearch.Hits)
            {
                switch (doc.Index)
                {
                    case "forms2":                        
                        lstObject.Add(JsonConvert.DeserializeObject<Form>(doc.Source.ToString()));
                        break;
                    case "jobs2":
                        lstObject.Add(JsonConvert.DeserializeObject<ApplicationClasses.Job>(doc.Source.ToString()));
                        break;
                    case "mailcomments2":
                        lstObject.Add(JsonConvert.DeserializeObject<MailComment>(doc.Source.ToString()));
                        break;
                    default:
                        break;
                }
            }

            foreach (var item in lstObject)
            {
                if (item is ApplicationClasses.Job)
                {
                    ProcessJobEntity((ApplicationClasses.Job)item, lstObject);
                }
            }
        }

        public static ApplicationClasses.Job ProcessJobEntity(ApplicationClasses.Job job, ArrayList lstDocuments)
        {

            return new ApplicationClasses.Job();
        }

        public static void CreateJobIndexMapping(ElasticClient client)
        {
            // add Overview, Conclusion, MailComments, CheckIns..as non-indexable
            // no need, since it's not going to store value into the fields. Its for UI purpose..
            var jobIndex = client.CreateIndex("jobs2", c => c
                   .Mappings(ms => ms
                     .Map<ApplicationClasses.Job>(m => m
                         .AutoMap()
                         .Properties(p1 => p1
                             .Text(s => s
                                 .Name(e => e.Type)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_id)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_teamId)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_teamIcon)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_createdById)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_createdBy)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_updatedById)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_updatedBy)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_createdDateTime)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_updatedDateTime)
                                 .Index(false))
                                 ))));
        }

        public static void CreateFormIndexMapping(ElasticClient client)
        {
            var jobIndex = client.CreateIndex("forms2", c => c
                   .Mappings(ms => ms
                     .Map<Form>(m => m
                         .AutoMap()
                         .Properties(p1 => p1
                             .Text(s => s
                                 .Name(e => e.Type)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_id)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_teamId)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_teamIcon)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_createdById)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_createdBy)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_updatedById)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_updatedBy)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_createdDateTime)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_updatedDateTime)
                                 .Index(false))
                              .Text(s => s
                                 .Name(e => e.Additonal_icon)
                                 .Index(false))
                                 ))));
        }

        public static void CreateMailCommentIndexMapping(ElasticClient client)
        {
            var jobIndex = client.CreateIndex("mailcomments2", c => c
                   .Mappings(ms => ms
                     .Map<MailComment>(m => m
                         .AutoMap()
                         .Properties(p1 => p1
                             .Text(s => s
                                 .Name(e => e.Type)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_id)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_teamId)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_teamIcon)
                                 .Index(false))

                             .Text(s => s
                                 .Name(e => e.Additional_jobId)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_jobTitle)
                                 .Index(false))

                             .Text(s => s
                                 .Name(e => e.Additional_createdById)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_createdBy)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_updatedById)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_updatedBy)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_createdDateTime)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.Additional_updatedDateTime)
                                 .Index(false))

                              .Text(s => s
                                 .Name(e => e.Additional_teamName)
                                 .Index(false))
                              .Text(s => s
                                 .Name(e => e.Additional_fromUserId)
                                 .Index(false))
                              .Text(s => s
                                 .Name(e => e.Additional_reportGeneratedBy)
                                 .Index(false))
                              .Text(s => s
                                 .Name(e => e.Additional_reportGeneratedById)
                                 .Index(false))
                                 ))));
        }
    }
}
