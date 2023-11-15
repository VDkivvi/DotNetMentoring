namespace ReflectionTask.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SystemEnvNameAttribute : ConfigNameAttribute
    {
        public SystemEnvNameAttribute(string settingName) : base(settingName)
        {
        }
    }
}
