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
using System.Linq;
using Demo_Elastic_Search.Enum;
using Demo_Elastic_Search.ApplicationClasses.OutputClasses;

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
                Type = EntityType.MailComment.ToString(),
                Message = "Test mail message 1",
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
                Type = EntityType.Job.ToString(),
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
                Type = EntityType.Form.ToString(),
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
            var type = EntityType.Job;
            var pageno = 1;
            var from = ((pageno - 1) * 10);
            string search = "test";

            var resSearch = client.Search<dynamic>(s => s
                     .AllIndices()
                     .AllTypes()
                     .Size(10)
                     .From(from)
                     .Query(q => q
                         .QueryString(qs => qs.Query(search))));


            // code to give json output to mobile end....
            var filteredList = resSearch.Documents.Select(doc =>
            {
                switch (doc.type.ToString())
                {
                    case nameof(EntityType.Form):
                        return JsonConvert.DeserializeObject<FormAc>(doc.ToString());
                    case nameof(EntityType.Job):
                        return JsonConvert.DeserializeObject<JobAc>(doc.ToString());
                    case nameof(EntityType.JobPage):
                        return JsonConvert.DeserializeObject<JobPageAc>(doc.ToString());
                    case nameof(EntityType.Asset):
                        return JsonConvert.DeserializeObject<AssetAc>(doc.ToString());
                    case nameof(EntityType.Attachment):
                        return JsonConvert.DeserializeObject<AttachmentAc>(doc.ToString());
                    case nameof(EntityType.CheckIn):
                        return JsonConvert.DeserializeObject<CheckInAc>(doc.ToString());

                    case nameof(EntityType.Image):
                        return JsonConvert.DeserializeObject<MediaAc>(doc.ToString());
                    case nameof(EntityType.Audio):
                        return JsonConvert.DeserializeObject<MediaAc>(doc.ToString());
                    case nameof(EntityType.Video):
                        return JsonConvert.DeserializeObject<MediaAc>(doc.ToString());
                    default:
                        return JsonConvert.DeserializeObject<MailCommentAc>(doc.ToString());
                }
            }).ToList();

            foreach (var item in filteredList)
            {
                if (item is JobAc)
                {
                    ProcessJobEntity(item, filteredList);
                }
            }
        }

        public static ApplicationClasses.Job ProcessJobEntity(JobAc jobAc, List<dynamic> lstDocuments)
        {
            var lstMailComments = lstDocuments.Where(p => p.Additional_jobId == jobAc.Id && p.Type.ToString() == EntityType.MailComment.ToString()).ToList();

            var lstMailCommentAc = lstMailComments.Select(doc =>
            {
                return JsonConvert.DeserializeObject<MailCommentAc>(doc.ToString());
            }).ToList();

            if (lstMailComments.Any())
            {
                jobAc.MailComments = lstMailComments;
            }

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
