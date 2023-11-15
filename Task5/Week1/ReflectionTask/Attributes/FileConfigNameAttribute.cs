namespace ReflectionTask.Attributes
{
    public class JsonConfigNameAttribute : ConfigNameAttribute
    {
        public JsonConfigNameAttribute(string settingName) : base(settingName)
        {
        }
    }
}
