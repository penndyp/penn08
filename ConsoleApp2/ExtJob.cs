using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace ConsoleApp2
{
    public class ExtJob : ICustomerJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var id = context.Trigger.JobKey.Name.Split('_')[1];
            var obj = db.GetExt(Convert.ToInt32(id));
            Console.WriteLine(obj.Express +"\t"+DateTime.Now);
        }

        public string GetCronExpression(object id)
        {
           return db.GetExt(Convert.ToInt32 ( id)).Express;
        }
    }
}
