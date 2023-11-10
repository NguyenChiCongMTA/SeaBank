using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.IO;
using Quartz.Impl;
using Quartz;
using SafeControl.Classes.JobConfig;

namespace SafeControl
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();

            string text = File.ReadAllText($@"{Application.StartupPath}{Constants.FilePathConstant.JOB_CONFIG}");
            var jobConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<JobConfig>(text);


            // Grab the Scheduler instance from the Factory
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler();

            scheduler.Start();
            
            int i = 1;
            foreach (var item in jobConfig.EmailJobs)
            {
                IJobDetail job = JobBuilder.Create<SendEmailJob>().Build();
                var jobTime = DateTime.Parse(s: item.EmailTime);
                ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity($"EmailJob_{++i}", $"EmailJobs")
               .StartAt(DateTime.Now.Date)
               .WithPriority(1)
               .WithCronSchedule($"{jobTime.Second} {jobTime.Minute} {jobTime.Hour} ? * * *")
               .Build();
                scheduler.ScheduleJob(job, trigger);
            }

            i = 1;
            foreach (var item in jobConfig.SmsJobs)
            {
                IJobDetail job = JobBuilder.Create<SendEmailJob>().Build();
                var jobTime = DateTime.Parse(s: item.SmsTime);
                ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity($"SmsJob_{++i}", $"SmsJobs")
               .StartAt(DateTime.Now.Date)
               .WithPriority(1)
               .WithCronSchedule($"{jobTime.Second} {jobTime.Minute} {jobTime.Hour} ? * * *")
               .Build();
                scheduler.ScheduleJob(job, trigger);
            }

            if(!string.IsNullOrEmpty(jobConfig.RefreshDataJob))
            {
                IJobDetail job = JobBuilder.Create<RefreshDataJob>().Build();
                var jobTime = DateTime.Parse(jobConfig.RefreshDataJob);
                ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity($"RefreshJob", $"RefreshJobs")
               .StartAt(DateTime.Now.Date)
               .WithPriority(1)
               .WithCronSchedule($"{jobTime.Second} {jobTime.Minute} {jobTime.Hour} ? * * *")
               .Build();
                scheduler.ScheduleJob(job, trigger);
            }    

            Application.Run(new f0HomeLogin());
           


            //Application.Run(new TestForm());
            //Application.Run(new Base.fEncrypt());
            //Application.Run(new fConnect());
        }
    }

    

   
}
