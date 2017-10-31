using Quartz;


namespace ConsoleApp2
{
    public interface ICustomerJob:IJob
    {
        string GetCronExpression(object id);
    }
}
