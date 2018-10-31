using Demo_Elastic_Search.ApplicationClasses;
using Demo_Elastic_Search.ApplicationClasses.OutputClasses;
using System;
using System.Collections.Generic;

namespace Demo_Elastic_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            InitializeAutomapper();
            ElasticSearch1.TestMethod();
        }

        static void InitializeAutomapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Job, JobAc>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.AdditionalId))
                .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.AdditionalJobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.AdditionalJobTitle))
                .ForMember(x => x.JobDescription, opt => opt.MapFrom(src => src.AdditionalJobDescription))
                .ForMember(x => x.JobAddress, opt => opt.MapFrom(src => src.AdditionalJobAddress))
                .ForMember(x => x.JobUpdatedBy, opt => opt.MapFrom(src => src.AdditionalJobUpdatedBy))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobCreatedDateTime))
                .ForMember(x => x.JobUpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobUpdatedDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.AdditionalTeamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.AdditionalTeamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalTeamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.AdditionalTeamUpdatedDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.AdditionalCreatedById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.AdditionalCreatedBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.AdditionalUpdatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.AdditionalUpdatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.AdditionalCreatedDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalUpdatedDateTime))
                .ForMember(x => x.UsedIn, opt => opt.MapFrom(src => new List<UsedIn>()))
                .ReverseMap();

                cfg.CreateMap<Form, FormAc>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.AdditionalId))
                .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.AdditionalJobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.AdditionalJobTitle))
                .ForMember(x => x.JobDescription, opt => opt.MapFrom(src => src.AdditionalJobDescription))
                .ForMember(x => x.JobAddress, opt => opt.MapFrom(src => src.AdditionalJobAddress))
                .ForMember(x => x.JobUpdatedBy, opt => opt.MapFrom(src => src.AdditionalJobUpdatedBy))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobCreatedDateTime))
                .ForMember(x => x.JobUpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobUpdatedDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.AdditionalTeamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.AdditionalTeamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalTeamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.AdditionalTeamUpdatedDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.AdditionalCreatedById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.AdditionalCreatedBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.AdditionalUpdatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.AdditionalUpdatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.AdditionalCreatedDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalUpdatedDateTime))

                .ForMember(x => x.Icon, opt => opt.MapFrom(src => src.AdditionalIcon))
                .ForMember(x => x.UsedIn, opt => opt.MapFrom(src => new List<UsedIn>()))
                .ReverseMap();

                cfg.CreateMap<MailComment, MailCommentAc>()
               .ForMember(x => x.Id, opt => opt.MapFrom(src => src.AdditionalId))
                .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.AdditionalJobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.AdditionalJobTitle))
                .ForMember(x => x.JobDescription, opt => opt.MapFrom(src => src.AdditionalJobDescription))
                .ForMember(x => x.JobAddress, opt => opt.MapFrom(src => src.AdditionalJobAddress))
                .ForMember(x => x.JobUpdatedBy, opt => opt.MapFrom(src => src.AdditionalJobUpdatedBy))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobCreatedDateTime))
                .ForMember(x => x.JobUpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobUpdatedDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.AdditionalTeamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.AdditionalTeamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalTeamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.AdditionalTeamUpdatedDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.AdditionalCreatedById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.AdditionalCreatedBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.AdditionalUpdatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.AdditionalUpdatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.AdditionalCreatedDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalUpdatedDateTime))

                .ForMember(x => x.TeamName, opt => opt.MapFrom(src => src.AdditionalTeamName))
                .ForMember(x => x.FromUserId, opt => opt.MapFrom(src => src.AdditionalFromUserId))
                .ForMember(x => x.ReportGeneratedById, opt => opt.MapFrom(src => src.AdditionalReportGeneratedById))
                .ForMember(x => x.ReportGeneratedBy, opt => opt.MapFrom(src => src.ReportGeneratedBy))
                .ForMember(x => x.UsedIn, opt => opt.MapFrom(src => new List<UsedIn>()))
               .ReverseMap();

                cfg.CreateMap<CheckIn, CheckInAc>()
               .ForMember(x => x.Id, opt => opt.MapFrom(src => src.AdditionalId))
                .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.AdditionalJobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.AdditionalJobTitle))
                .ForMember(x => x.JobDescription, opt => opt.MapFrom(src => src.AdditionalJobDescription))
                .ForMember(x => x.JobAddress, opt => opt.MapFrom(src => src.AdditionalJobAddress))
                .ForMember(x => x.JobUpdatedBy, opt => opt.MapFrom(src => src.AdditionalJobUpdatedBy))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobCreatedDateTime))
                .ForMember(x => x.JobUpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobUpdatedDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.AdditionalTeamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.AdditionalTeamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalTeamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.AdditionalTeamUpdatedDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.AdditionalCreatedById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.AdditionalCreatedBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.AdditionalUpdatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.AdditionalUpdatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.AdditionalCreatedDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalUpdatedDateTime))

                .ForMember(x => x.Lat, opt => opt.MapFrom(src => src.AdditionalLatitude))
                .ForMember(x => x.Long, opt => opt.MapFrom(src => src.AdditionalLongitude))
                .ForMember(x => x.UsedIn, opt => opt.MapFrom(src => new List<UsedIn>()))
               .ReverseMap();

                cfg.CreateMap<JobPage, JobPageAc>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.AdditionalId))
                .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.AdditionalJobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.AdditionalJobTitle))
                .ForMember(x => x.JobDescription, opt => opt.MapFrom(src => src.AdditionalJobDescription))
                .ForMember(x => x.JobAddress, opt => opt.MapFrom(src => src.AdditionalJobAddress))
                .ForMember(x => x.JobUpdatedBy, opt => opt.MapFrom(src => src.AdditionalJobUpdatedBy))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobCreatedDateTime))
                .ForMember(x => x.JobUpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobUpdatedDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.AdditionalTeamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.AdditionalTeamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalTeamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.AdditionalTeamUpdatedDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.AdditionalCreatedById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.AdditionalCreatedBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.AdditionalUpdatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.AdditionalUpdatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.AdditionalCreatedDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalUpdatedDateTime))

                .ForMember(x => x.FieldsInJson, opt => opt.MapFrom(src => src.FieldsInJson))
                .ForMember(x => x.UsedIn, opt => opt.MapFrom(src => new List<UsedIn>()))
                .ReverseMap();

                cfg.CreateMap<FieldsInJson, FieldsInJsonAc>().ReverseMap();

                cfg.CreateMap<Asset, AssetAc>()
               .ForMember(x => x.Id, opt => opt.MapFrom(src => src.AdditionalId))
               .ForMember(x => x.UsedIn, opt => opt.MapFrom(src => new List<UsedIn>()))
               .ReverseMap();

                cfg.CreateMap<Attachment, AttachmentAc>()
              .ForMember(x => x.Id, opt => opt.MapFrom(src => src.AdditionalId))
                .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.AdditionalJobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.AdditionalJobTitle))
                .ForMember(x => x.JobDescription, opt => opt.MapFrom(src => src.AdditionalJobDescription))
                .ForMember(x => x.JobAddress, opt => opt.MapFrom(src => src.AdditionalJobAddress))
                .ForMember(x => x.JobUpdatedBy, opt => opt.MapFrom(src => src.AdditionalJobUpdatedBy))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobCreatedDateTime))
                .ForMember(x => x.JobUpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobUpdatedDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.AdditionalTeamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.AdditionalTeamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalTeamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.AdditionalTeamUpdatedDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.AdditionalCreatedById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.AdditionalCreatedBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.AdditionalUpdatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.AdditionalUpdatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.AdditionalCreatedDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalUpdatedDateTime))

                .ForMember(x => x.TeamName, opt => opt.MapFrom(src => src.AdditionalTeamName))
                .ForMember(x => x.MailCommentId, opt => opt.MapFrom(src => src.AdditionalMailCommentId))
                .ForMember(x => x.FileSize, opt => opt.MapFrom(src => src.AdditionalFileSize))
                .ForMember(x => x.FileUrl, opt => opt.MapFrom(src => src.AdditionalFileUrl))
                .ForMember(x => x.ShortenUrl, opt => opt.MapFrom(src => src.AdditionalShortenUrl))
                .ForMember(x => x.UsedIn, opt => opt.MapFrom(src => new List<UsedIn>()))
              .ReverseMap();

                cfg.CreateMap<Media, MediaAc>()
               .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.AdditionalJobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.AdditionalJobTitle))
                .ForMember(x => x.JobDescription, opt => opt.MapFrom(src => src.AdditionalJobDescription))
                .ForMember(x => x.JobAddress, opt => opt.MapFrom(src => src.AdditionalJobAddress))
                .ForMember(x => x.JobUpdatedBy, opt => opt.MapFrom(src => src.AdditionalJobUpdatedBy))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobCreatedDateTime))
                .ForMember(x => x.JobUpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalJobUpdatedDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.AdditionalTeamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.AdditionalTeamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.AdditionalTeamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.AdditionalTeamUpdatedDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.AdditionalCreatedById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.AdditionalCreatedBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.AdditionalUpdatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.AdditionalUpdatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.AdditionalCreatedDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.AdditionalUpdatedDateTime))

                .ForMember(x => x.MediaType, opt => opt.MapFrom(src => src.AdditionalMediaType))
                .ForMember(x => x.AudioUrl, opt => opt.MapFrom(src => src.AdditionalAudioUrl))
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(src => src.AdditionalImageUrl))
                .ForMember(x => x.VideoUrl, opt => opt.MapFrom(src => src.AdditionalVideoUrl))
                .ForMember(x => x.VideoThumbNailUrl, opt => opt.MapFrom(src => src.AdditionalVideoThumbNailUrl))
                .ForMember(x => x.ShortenUrl, opt => opt.MapFrom(src => src.AdditionalShortenUrl))

                .ForMember(x => x.Latitude, opt => opt.MapFrom(src => src.AdditionalLatitude))
                .ForMember(x => x.Longtitude, opt => opt.MapFrom(src => src.AdditionalLongtitude))
                .ForMember(x => x.Size, opt => opt.MapFrom(src => src.AdditionalSize))
                .ForMember(x => x.Duration, opt => opt.MapFrom(src => src.AdditionalDuration))
                .ForMember(x => x.MediaLatitude, opt => opt.MapFrom(src => src.AdditionalMediaLatitude))
                .ForMember(x => x.MediaLongtitude, opt => opt.MapFrom(src => src.AdditionalMediaLongtitude))
                .ForMember(x => x.MediaLocation, opt => opt.MapFrom(src => src.AdditionalMediaLocation))
                .ForMember(x => x.MediaBreadCrumb, opt => opt.MapFrom(src => src.AdditionalMediaBreadCrumb))
                .ForMember(x => x.UsedIn, opt => opt.MapFrom(src => new List<UsedIn>()))
               .ReverseMap();
            });
        }
    }
}
