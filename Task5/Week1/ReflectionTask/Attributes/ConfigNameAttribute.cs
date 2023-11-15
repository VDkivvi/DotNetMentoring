namespace ReflectionTask.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class ConfigNameAttribute : Attribute
    {
        public string Name;

        public ConfigNameAttribute(string settingName)
            => Name = settingName;
    }
}
