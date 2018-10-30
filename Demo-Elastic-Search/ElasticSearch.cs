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
                                     .DefaultMappingFor<ApplicationClasses.Job>(i => i.IdProperty("AdditionalId"))
                                     .DefaultMappingFor<Form>(i => i.IdProperty("AdditionalId"))
                                     .DefaultMappingFor<MailComment>(i => i.IdProperty("AdditionalId"))
                                     .PrettyJson()
                                     .RequestTimeout(TimeSpan.FromMinutes(2));

            var client = new ElasticClient(connectionSettings);
            CreateJobIndexMapping(client);
            CreateFormIndexMapping(client);
            CreateMailCommentIndexMapping(client);

            var mailComment = new MailComment()
            {
                Type = EntityType.MailComment.ToString(),
                Message = "Test mail message 1",
                FromEmail = "abc1@mailinator.com",
                CC = new string[] { "abc1@mailinator.com", "abc2@mailinator.com" },
                Attachments = new string[] { "File1.xlz", "File_Image.xlxs" },
                Subject = "Subject for the mail coment will be ",
                AdditionalId = "16f71517-1124-43b7-bebe-6387999a87bd",
                AdditionalJobId = "16f71517-1124-43b7-bebe-6387999a87bd",
                AdditionalJobTitle = "Job Title",
                AdditionalTeamId = "16f71517-1124-43b7-bebe-6387999a87bd",
                AdditionalTeamName = "Corpac",
                AdditionalTeamIcon = "https://devapps.visualogyx.com/team-icon.png",
                AdditionalFromUserId = "abc1@mailinator.com",
                AdditionalReportGeneratedById = "16f71517-1124-43b7-bebe-6387999a87bd",
                ReportGeneratedBy = "ABC",
                AdditionalCreatedDateTime = DateTime.Now,
                AdditionalUpdatedDateTime = DateTime.Now
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
                AdditionalTeamId = "16f71517-1124-43b7-bebe-6387999a87bd",
                AdditionalTeamIcon = "https://devapps.visualogyx.com/team-icon.png",
                AdditionalId = "16f71517-1124-43b7-bebe-6387999a87bd",
                AdditionalCreatedById = "16f71517-1124-43b7-bebe-6387999a87bd",
                AdditionalCreatedBy = "ABC",
                AdditionalUpdatedById = "16f71517-1124-43b7-bebe-6387999a87bd",
                AdditionalUpdatedBy = "XYZ",
                AdditionalCreatedDateTime = DateTime.Now,
                AdditionalUpdatedDateTime = DateTime.Now
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
                AdditionalIcon = "https://devapps.visualogyx.com/team-icon.png",
                AdditionalId = "16f71517-1124-43b7-bebe-6387999a87bF",
                AdditionalTeamId = "16f71517-1124-43b7-bebe-6387999a87bd",
                AdditionalTeamIcon = "https://devapps.visualogyx.com/team-icon.png",
                AdditionalCreatedById = "16f71517-1124-43b7-bebe-6387999a87bd",
                AdditionalCreatedBy = "ABC",
                AdditionalUpdatedById = "16f71517-1124-43b7-bebe-6387999a87bd",
                AdditionalUpdatedBy = "XYZ",
                AdditionalCreatedDateTime = DateTime.Now,
                AdditionalUpdatedDateTime = DateTime.Now
            };

            var resForm = client.Index(form, i => i
                       .Index("forms2")
                       .Type("form"));


            // code for search..
            var type = EntityType.Job.ToString();
            var pageNo = 1;
            var from = ((pageNo - 1) * 10);
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
                        var formObj = JsonConvert.DeserializeObject<Form>(doc.ToString());
                        return AutoMapper.Mapper.Map<FormAc>(formObj);
                    case nameof(EntityType.Job):
                        var jobObj = JsonConvert.DeserializeObject<ApplicationClasses.Job>(doc.ToString());
                        return AutoMapper.Mapper.Map<JobAc>(jobObj);
                    case nameof(EntityType.JobPage):
                        var jobPageObj = JsonConvert.DeserializeObject<JobPage>(doc.ToString());
                        return AutoMapper.Mapper.Map<JobPageAc>(jobPageObj);
                    case nameof(EntityType.Asset):
                        var assetObj = JsonConvert.DeserializeObject<Asset>(doc.ToString());
                        return AutoMapper.Mapper.Map<AssetAc>(assetObj);
                    case nameof(EntityType.Attachment):
                        var attachmentObj = JsonConvert.DeserializeObject<ApplicationClasses.Attachment>(doc.ToString());
                        return AutoMapper.Mapper.Map<AttachmentAc>(attachmentObj);
                    case nameof(EntityType.CheckIn):
                        var checkInObj = JsonConvert.DeserializeObject<CheckIn>(doc.ToString());
                        return AutoMapper.Mapper.Map<CheckInAc>(checkInObj);
                    case nameof(EntityType.Image):
                    case nameof(EntityType.Audio):
                    case nameof(EntityType.Video):
                        var mediaObj = JsonConvert.DeserializeObject<Media>(doc.ToString());
                        return AutoMapper.Mapper.Map<MediaAc>(mediaObj);
                    default:
                        var mailCommentObj = JsonConvert.DeserializeObject<MailComment>(doc.ToString());
                        return AutoMapper.Mapper.Map<MailCommentAc>(mailCommentObj);
                }
            }).ToList();

            var filteredJobList = filteredList.Where(p => p.Type == EntityType.Job.ToString()).ToList();


            for (int index = 0; index < filteredList.Count; index++)
            {
                var item = filteredList[index];
                if (item is JobAc)
                {
                    item = ProcessJobEntity(item, ref filteredList);
                }
                else if (item is FormAc)
                {
                    item = ProcessFormEntity(item, filteredJobList);
                }
            }

            var filteredMailComment = filteredList.Where(p => p.Type == EntityType.MailComment.ToString()).ToList();

            for (int index = 0; index < filteredList.Count; index++)
            {
                var item = filteredList[index];
                if (item is MailCommentAc)
                {
                    item = ProcessMailComments(item, filteredMailComment);
                }
            }

            
        }

        public static JobAc ProcessMailComments(MailCommentAc mailComment, List<dynamic> lstFilteredMailComment)
        {
            var groupedList = lstFilteredMailComment.GroupBy(x => x.JobId == mailComment.JobId).ToList();
            foreach (var item in groupedList)
            {
                var jobId = item.Key;

                var allJobsInCurrentJobId = item.ToList();
            }

            return new JobAc();
        }

        public static FormAc ProcessFormEntity(FormAc formAc, List<dynamic> lstFilteredJobList)
        {
            var getAllMatchingJobs = lstFilteredJobList.Where(p => p.Id == formAc.JobId && p.Type == EntityType.Job.ToString()).ToList();
            if (getAllMatchingJobs.Any())
            {
                formAc.UsedIn.Add(new UsedIn() { Type = EntityType.Job.ToString(), Name = "Job", Entity = getAllMatchingJobs });
            }
            return formAc;
        }

        public static JobAc ProcessJobEntity(JobAc jobAc, ref List<dynamic> lstDocuments)
        {
            #region "MailComments"

            var lstMailComments = lstDocuments.Where(p => p.JobId == jobAc.Id && p.Type.ToString() == EntityType.MailComment.ToString()).ToList();

            if (lstMailComments.Any())
            {
                lstDocuments.RemoveAll(p => p.JobId == jobAc.Id && p.Type.ToString() == EntityType.MailComment.ToString());
                jobAc.UsedIn.Add(new UsedIn() { Type = EntityType.MailComment.ToString(), Name = "Mail Comments", Entity = lstMailComments });
            }

            #endregion

            #region "CheckIns"

            var lstCheckIns = lstDocuments.Where(p => p.JobId == jobAc.Id && p.Type.ToString() == EntityType.CheckIn.ToString()).ToList();

            if (lstCheckIns.Any())
            {
                lstDocuments.RemoveAll(p => p.JobId == jobAc.Id && p.Type.ToString() == EntityType.CheckIn.ToString());
                jobAc.UsedIn.Add(new UsedIn() { Type = EntityType.CheckIn.ToString(), Name = "Check Ins", Entity = lstCheckIns });
            }

            #endregion

            #region "Overview"
            var lstOverview = lstDocuments.Where(p => p.JobId == jobAc.Id && p.Type.ToString() == EntityType.Overview.ToString()).ToList();

            if (lstOverview.Any())
            {
                lstDocuments.RemoveAll(p => p.JobId == jobAc.Id && p.Type.ToString() == EntityType.Overview.ToString());

            }

            #endregion

            #region "Conclusion"
            var lstConclusion = lstDocuments.Where(p => p.JobId == jobAc.Id && p.Type.ToString() == EntityType.Conclusion.ToString()).ToList();

            if (lstConclusion.Any())
            {
                lstDocuments.RemoveAll(p => p.JobId == jobAc.Id && p.Type.ToString() == EntityType.Conclusion.ToString());
                jobAc.UsedIn.Add(new UsedIn() { Type = EntityType.Conclusion.ToString(), Name = "Conclusion", Entity = lstConclusion });
            }

            #endregion

            return jobAc;
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
                                 .Name(e => e.AdditionalId)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalTeamId)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalTeamIcon)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalCreatedById)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalCreatedBy)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalUpdatedById)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalUpdatedBy)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalCreatedDateTime)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalUpdatedDateTime)
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
                                 .Name(e => e.AdditionalId)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalTeamId)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalTeamIcon)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalCreatedById)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalCreatedBy)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalUpdatedById)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalUpdatedBy)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalCreatedDateTime)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalUpdatedDateTime)
                                 .Index(false))
                              .Text(s => s
                                 .Name(e => e.AdditionalIcon)
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
                                 .Name(e => e.AdditionalId)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalTeamId)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalTeamIcon)
                                 .Index(false))

                             .Text(s => s
                                 .Name(e => e.AdditionalJobId)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalJobTitle)
                                 .Index(false))

                             .Text(s => s
                                 .Name(e => e.AdditionalCreatedById)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalCreatedBy)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalUpdatedById)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalUpdatedBy)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalCreatedDateTime)
                                 .Index(false))
                             .Text(s => s
                                 .Name(e => e.AdditionalUpdatedDateTime)
                                 .Index(false))

                              .Text(s => s
                                 .Name(e => e.AdditionalTeamName)
                                 .Index(false))
                              .Text(s => s
                                 .Name(e => e.AdditionalFromUserId)
                                 .Index(false))
                              .Text(s => s
                                 .Name(e => e.AdditionalReportGeneratedById)
                                 .Index(false))
                              .Text(s => s
                                 .Name(e => e.ReportGeneratedBy)
                                 )))));
        }
    }
}
