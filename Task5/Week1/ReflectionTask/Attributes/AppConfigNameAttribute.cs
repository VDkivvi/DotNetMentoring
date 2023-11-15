namespace ReflectionTask.Attributes
{
    public class AppConfigNameAttribute : ConfigNameAttribute
    {
        public AppConfigNameAttribute(string settingName) : base(settingName)
        {
        }
    }
}
