using ReflectionTask.Attributes;
using ReflectionTask.Configuration;
using ReflectionTask.POCO;

namespace ReflectionTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var envConfig = new ConfigComponent<EnvConfig>();
            //envConfig.LoadSettings();
            //Console.WriteLine(envConfig.Config);

            var application = new ConfigComponent<CustomConfig>();

            application.Using<AppConfigNameAttribute>().LoadSettings();
            Console.WriteLine(application.Config);

            application.Using<JsonConfigNameAttribute>().LoadSettings();
            Console.WriteLine(application.Config);

            application.SaveSettings("configuration.lastBuildNumber", "14");

            application.Using<AppConfigNameAttribute>().SaveSettings("build", "1000");

            Console.WriteLine(application.Config);
        }
    }
}