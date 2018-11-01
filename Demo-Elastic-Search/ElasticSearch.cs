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
                Contributors = new string[] { },
                Viewers = new string[] { "abc", "asd" },
                Inspectors = new string[] { "abc", "asd" },
                AdditionalTeamId = "16f71517-1124-43b7-bebe-6387999a87b5",
                AdditionalTeamIcon = "https://devapps.visualogyx.com/team-icon.png",
                AdditionalId = "16f71517-1124-43b7-bebe-6387999a87b5",
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
            if (type == EntityType.All.ToString())
            {
                type = "_all";
            }
            var pageNo = 1;
            var from = ((pageNo - 1) * 10);
            string search = "Test";

            // applied And operator because when search with Job Description it gives perfect result, when
            // applied OR operator it gave incorrect result.
            var resSearch = client.Search<dynamic>(s => s
                     .Index(type)
                     .AllTypes()
                     .Size(10)
                     .From(from)
                     .Query(q => q
                         .QueryString(qs => qs
                            .Query(search)
                            .DefaultOperator(Operator.And)))
                     .Highlight(h => h
                        .Fields(p => p
                            .AllField())));


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
                        var imageObj = JsonConvert.DeserializeObject<Media>(doc.ToString());
                        return AutoMapper.Mapper.Map<ImageAc>(imageObj);
                    case nameof(EntityType.Audio):
                        var audioObj = JsonConvert.DeserializeObject<Media>(doc.ToString());
                        return AutoMapper.Mapper.Map<AudioAc>(audioObj);
                    case nameof(EntityType.Video):
                        var videoObj = JsonConvert.DeserializeObject<Media>(doc.ToString());
                        return AutoMapper.Mapper.Map<VideoAc>(videoObj);
                    default:
                        var mailCommentObj = JsonConvert.DeserializeObject<MailComment>(doc.ToString());
                        return AutoMapper.Mapper.Map<MailCommentAc>(mailCommentObj);
                }
            }).ToList();


            // code to filter jobs based on its valid job..


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
                    // here filteredJobList is passed because from that jobs only i need to search..
                    item = ProcessFormEntity(item, filteredJobList);
                }
            }

            var filteredMailComment = filteredList.Where(p => p.Type == EntityType.MailComment.ToString()).ToList();
            var filteredCheckIn = filteredList.Where(p => p.Type == EntityType.CheckIn.ToString()).ToList();
            var filteredAttachment = filteredList.Where(p => p.Type == EntityType.Attachment.ToString()).ToList();
            var filteredImage = filteredList.Where(p => p.Type == EntityType.Image.ToString()).ToList();
            var filteredAudio = filteredList.Where(p => p.Type == EntityType.Audio.ToString()).ToList();
            var filteredVideo = filteredList.Where(p => p.Type == EntityType.Video.ToString()).ToList();


            for (int index = 0; index < filteredList.Count; index++)
            {
                var item = filteredList[index];
                if (item is MailCommentAc)
                {
                    item = ProcessJobWise(item, ref filteredMailComment, EntityType.MailComment.ToString(), "Mail Comment");
                    filteredList[index] = item;
                }
                else if (item is CheckInAc)
                {
                    item = ProcessJobWise(item, ref filteredCheckIn, EntityType.CheckIn.ToString(), "CheckIn");
                    filteredList[index] = item;
                }
                else if (item is AttachmentAc)
                {
                    item = ProcessJobWise(item, ref filteredAttachment, EntityType.Attachment.ToString(), "Attachment");
                    filteredList[index] = item;
                }
                else if (item is ImageAc)
                {
                    item = ProcessJobWise(item, ref filteredImage, EntityType.Image.ToString(), "Image");
                    filteredList[index] = item;
                }
                else if (item is AudioAc)
                {
                    item = ProcessJobWise(item, ref filteredAudio, EntityType.Audio.ToString(), "Audio");
                    filteredList[index] = item;
                }
                else if (item is VideoAc)
                {
                    item = ProcessJobWise(item, ref filteredVideo, EntityType.Video.ToString(), "Video");
                    filteredList[index] = item;
                }
            }
        }

        public static JobAc ProcessJobWise(dynamic item, ref List<dynamic> lstFilteredItems, string type, string entityName)
        {
            var groupedList = lstFilteredItems.GroupBy(x => x.JobId).ToList().Select(x => new { key = x.Key, lstItems = x.ToList() });
            var getKeyObject = groupedList.FirstOrDefault(x => x.key == item.JobId);

            if (getKeyObject != null && getKeyObject.lstItems.Count > 0)
            {
                var jobAc = new JobAc
                {
                    Type = type,
                    Id = item.JobId,
                    Title = item.JobTitle,
                    Description = item.JobDescription,
                    Address = item.JobAddress,

                    CreatedDateTime = item.JobCreatedDateTime,
                    UpdatedDateTime = item.JobUpdatedDateTime,
                    UpdatedBy = item.JobUpdatedBy,

                    TeamName = item.TeamName,
                    TeamIcon = item.TeamIcon,
                    UsedIn = new List<UsedIn>()
                };

                foreach (var singleItem in getKeyObject.lstItems)
                {
                    jobAc.UsedIn.Add(new UsedIn() { Type = type, Name = entityName, Entity = new List<dynamic> { (dynamic)singleItem } });
                }

                lstFilteredItems.RemoveAll(x => x.JobId == item.JobId);

                return jobAc;
            }
            return null;
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
