using Demo_Elastic_Search.ApplicationClasses;
using Demo_Elastic_Search.ApplicationClasses.OutputClasses;
using System;

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
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Additional_id))
                .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.Additional_jobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.Additional_jobTitle))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.Additional_jobCreatedDateTime))
                .ForMember(x => x.JobUpdateDateTime, opt => opt.MapFrom(src => src.Additional_jobUpdateDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.Additional_teamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.Additional_teamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.Additional_teamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.Additional_teamUpdateDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.Additional_createdById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.Additional_createdBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.Additional_updatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.Additional_updatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.Additional_createdDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.Additional_updatedDateTime))
                .ReverseMap();

                cfg.CreateMap<Form, FormAc>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Additional_id))
                .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.Additional_jobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.Additional_jobTitle))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.Additional_jobCreatedDateTime))
                .ForMember(x => x.JobUpdateDateTime, opt => opt.MapFrom(src => src.Additional_jobUpdateDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.Additional_teamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.Additional_teamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.Additional_teamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.Additional_teamUpdateDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.Additional_createdById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.Additional_createdBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.Additional_updatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.Additional_updatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.Additional_createdDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.Additional_updatedDateTime))

                .ForMember(x => x.Icon, opt => opt.MapFrom(src => src.Additional_icon))
                .ReverseMap();

                cfg.CreateMap<MailComment, MailCommentAc>()
               .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Additional_id))
                .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.Additional_jobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.Additional_jobTitle))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.Additional_jobCreatedDateTime))
                .ForMember(x => x.JobUpdateDateTime, opt => opt.MapFrom(src => src.Additional_jobUpdateDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.Additional_teamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.Additional_teamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.Additional_teamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.Additional_teamUpdateDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.Additional_createdById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.Additional_createdBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.Additional_updatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.Additional_updatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.Additional_createdDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.Additional_updatedDateTime))

                .ForMember(x => x.TeamName, opt => opt.MapFrom(src => src.Additional_teamName))
                .ForMember(x => x.FromUserId, opt => opt.MapFrom(src => src.Additional_fromUserId))
                .ForMember(x => x.ReportGeneratedById, opt => opt.MapFrom(src => src.Additional_reportGeneratedById))
                .ForMember(x => x.ReportGeneratedBy, opt => opt.MapFrom(src => src.Additional_reportGeneratedBy))

               .ReverseMap();

                cfg.CreateMap<CheckIn, CheckInAc>()
               .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Additional_id))
                .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.Additional_jobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.Additional_jobTitle))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.Additional_jobCreatedDateTime))
                .ForMember(x => x.JobUpdateDateTime, opt => opt.MapFrom(src => src.Additional_jobUpdateDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.Additional_teamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.Additional_teamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.Additional_teamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.Additional_teamUpdateDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.Additional_createdById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.Additional_createdBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.Additional_updatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.Additional_updatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.Additional_createdDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.Additional_updatedDateTime))

                .ForMember(x => x.Lat, opt => opt.MapFrom(src => src.Additional_lat))
                .ForMember(x => x.Long, opt => opt.MapFrom(src => src.Additional_long))
               .ReverseMap();

                cfg.CreateMap<JobPage, JobPageAc>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Additional_id))
                .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.Additional_jobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.Additional_jobTitle))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.Additional_jobCreatedDateTime))
                .ForMember(x => x.JobUpdateDateTime, opt => opt.MapFrom(src => src.Additional_jobUpdateDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.Additional_teamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.Additional_teamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.Additional_teamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.Additional_teamUpdateDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.Additional_createdById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.Additional_createdBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.Additional_updatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.Additional_updatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.Additional_createdDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.Additional_updatedDateTime))

                .ForMember(x => x.FieldsInJson, opt => opt.MapFrom(src => src.FieldsInJson))
                .ReverseMap();

                cfg.CreateMap<FieldsInJson, FieldsInJsonAc>().ReverseMap();

                cfg.CreateMap<Asset, AssetAc>()
               .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Additional_id))
               .ReverseMap();

                cfg.CreateMap<Attachment, AttachmentAc>()
              .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Additional_id))
                .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.Additional_jobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.Additional_jobTitle))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.Additional_jobCreatedDateTime))
                .ForMember(x => x.JobUpdateDateTime, opt => opt.MapFrom(src => src.Additional_jobUpdateDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.Additional_teamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.Additional_teamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.Additional_teamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.Additional_teamUpdateDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.Additional_createdById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.Additional_createdBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.Additional_updatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.Additional_updatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.Additional_createdDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.Additional_updatedDateTime))

                .ForMember(x => x.TeamName, opt => opt.MapFrom(src => src.Additional_teamName))
                .ForMember(x => x.MailCommentId, opt => opt.MapFrom(src => src.Additional_mailCommentId))
                .ForMember(x => x.FileSize, opt => opt.MapFrom(src => src.Additional_fileSize))
                .ForMember(x => x.FileUrl, opt => opt.MapFrom(src => src.Additional_fileUrl))
                .ForMember(x => x.ShortenUrl, opt => opt.MapFrom(src => src.Additional_shortenUrl))                
              .ReverseMap();

                cfg.CreateMap<Media, MediaAc>()
               .ForMember(x => x.JobId, opt => opt.MapFrom(src => src.Additional_jobId))
                .ForMember(x => x.JobTitle, opt => opt.MapFrom(src => src.Additional_jobTitle))
                .ForMember(x => x.JobCreatedDateTime, opt => opt.MapFrom(src => src.Additional_jobCreatedDateTime))
                .ForMember(x => x.JobUpdateDateTime, opt => opt.MapFrom(src => src.Additional_jobUpdateDateTime))
                .ForMember(x => x.TeamId, opt => opt.MapFrom(src => src.Additional_teamId))
                .ForMember(x => x.TeamIcon, opt => opt.MapFrom(src => src.Additional_teamIcon))
                .ForMember(x => x.TeamCreatedDateTime, opt => opt.MapFrom(src => src.Additional_teamCreatedDateTime))
                .ForMember(x => x.TeamUpdateDateTime, opt => opt.MapFrom(src => src.Additional_teamUpdateDateTime))

                .ForMember(x => x.CreatedById, opt => opt.MapFrom(src => src.Additional_createdById))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.Additional_createdBy))
                .ForMember(x => x.UpdatedById, opt => opt.MapFrom(src => src.Additional_updatedById))
                .ForMember(x => x.UpdatedBy, opt => opt.MapFrom(src => src.Additional_updatedBy))
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(src => src.Additional_createdDateTime))
                .ForMember(x => x.UpdatedDateTime, opt => opt.MapFrom(src => src.Additional_updatedDateTime))

                .ForMember(x => x.MediaType, opt => opt.MapFrom(src => src.Additional_mediaType))
                .ForMember(x => x.AudioUrl, opt => opt.MapFrom(src => src.Additional_audioUrl))
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(src => src.Additional_imageUrl))
                .ForMember(x => x.VideoUrl, opt => opt.MapFrom(src => src.Additional_videoUrl))
                .ForMember(x => x.VideoThumbNailUrl, opt => opt.MapFrom(src => src.Additional_videoThumbNailUrl))
                .ForMember(x => x.ShortenUrl, opt => opt.MapFrom(src => src.Additional_shortenUrl))

                .ForMember(x => x.Latitude, opt => opt.MapFrom(src => src.Additional_latitude))
                .ForMember(x => x.Longtitude, opt => opt.MapFrom(src => src.Additional_longtitude))
                .ForMember(x => x.Size, opt => opt.MapFrom(src => src.Additional_size))
                .ForMember(x => x.Duration, opt => opt.MapFrom(src => src.Additional_duration))
                .ForMember(x => x.MediaLatitude, opt => opt.MapFrom(src => src.Additional_mediaLatitude))
                .ForMember(x => x.MediaLongtitude, opt => opt.MapFrom(src => src.Additional_mediaLongtitude))
                .ForMember(x => x.MediaLocation, opt => opt.MapFrom(src => src.Additional_mediaLocation))
                .ForMember(x => x.MediaBreadCrumb, opt => opt.MapFrom(src => src.Additional_mediaBreadCrumb))
               .ReverseMap();
            });
        }
    }
}
