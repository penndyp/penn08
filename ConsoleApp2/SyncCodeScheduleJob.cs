using NLog;
using Quartz;
using Quartz.Impl.Triggers;


namespace ConsoleApp2
{
    public class SyncCodeScheduleJob : IJob
    {

        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                var list = db.GetList();

                foreach (var item in list)
                {
                    Ex(item.ID,item.Express);
                }


                
            }
            catch (System.Exception ex)
            {
                
            }
            
         }

        private void Ex(int id,string ext)
        {
            var sched = ServiceRunner.scheduler;
            var jobkey = ScheduleHelper.GetJobKey<ExtJob>(id);
            if (jobkey != null)
            {
                var triggers = ServiceRunner.scheduler.GetTriggersOfJob(jobkey);
                if (triggers != null && triggers.Count > 0)
                {
                    var trigger = triggers[0] as CronTriggerImpl;
                    if (trigger != null)
                    {
                        var cronExp = trigger.CronExpressionString.Trim();                     
                        if (!cronExp.Equals(ext))
                        {
                            sched.DeleteJob(jobkey);
                            sched.BindCodeScheduler<ExtJob>(id);
                        }
                    }
                }
                else
                {
                    sched.BindCodeScheduler<ExtJob>(id);
                }
            }
        }
    }
}
