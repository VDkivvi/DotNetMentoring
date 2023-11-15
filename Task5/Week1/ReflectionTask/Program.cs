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

            //application.Using<FileConfigNameAttribute>().LoadSettings();
            //Console.WriteLine(application.Config);

            application.Using<AppConfigNameAttribute>().LoadSettings();
            Console.WriteLine(application.Config);

            //application.Using<AppConfigNameAttribute>().SaveSettings("build", envConfig.Config.LastBuildNumber);
            application.Using<AppConfigNameAttribute>().SaveSettings("build", "14");
            //application.Using<FileConfigNameAttribute>().SaveSettings("build", new DateTime(2023, 11, 22));

            Console.WriteLine(application.Config);
        }
    }
}