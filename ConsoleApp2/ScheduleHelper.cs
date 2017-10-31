
using ConsoleApp2;
using Quartz;
using Quartz.Impl.Triggers;

public static class ScheduleHelper
{
     public static void BindCodeScheduler<T>(this IScheduler sched,object id)
        where T : ICustomerJob,new()
    {
        var cronExpression = new T().GetCronExpression(id);
        if (string.IsNullOrEmpty(cronExpression)) return;
        var name = typeof(T).Name;
        var jobkey = GetJobKey<T>(id);
        var triggers = ServiceRunner.scheduler.GetTriggersOfJob(jobkey);
        if (triggers != null && triggers.Count > 0) return;
            var job = JobBuilder.Create<T>()
            .WithIdentity(jobkey)
            .Build();         
        var trigger = new CronTriggerImpl(name+id.ToString() + "Trigger", name + "Group", cronExpression);        
        sched.ScheduleJob(job, trigger);
    }
    public static JobKey GetJobKey<T>(object id)
    {
        return new JobKey(typeof(T).Name+"_"+id, "Sync");
    }
}
