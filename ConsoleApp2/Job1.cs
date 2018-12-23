using NLog;
using Quartz;
using System;
 

namespace ConsoleApp2
{
    public class Job1 : IJob
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public void Execute(IJobExecutionContext context)
        { 
            //123456
            var statrt = string.Format("{0:yyyy-MM-dd} 18:00:00", DateTime.Now.AddDays(-1));
            var end = string.Format("{0:yyyy-MM-dd} 18:00:00", DateTime.Now);
            logger.Error(string.Format("start:{0},end:{1}", statrt, end));
        }
    }
}
