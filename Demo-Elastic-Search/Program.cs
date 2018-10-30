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
                cfg.CreateMap<Job, JobAc>().ReverseMap();
            });
        }
    }
}
