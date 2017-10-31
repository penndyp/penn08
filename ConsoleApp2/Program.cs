using Topshelf;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ServiceRunner>();
                x.SetDescription("PennTimer Description");
                x.SetDisplayName("PennTimer DisplayName");
                x.SetServiceName("PennTimer ServiceName");
                x.EnablePauseAndContinue();
            });

        }
    }
}
