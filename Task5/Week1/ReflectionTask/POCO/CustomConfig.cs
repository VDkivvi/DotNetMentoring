using ReflectionTask.Attributes;


namespace ReflectionTask.POCO
{
    public record CustomConfig
    {
        [AppConfigName("build"), FileConfigName("LastBuildNumber")]
        public int LastBuildNumber { get; set; }

        [AppConfigName("name"), FileConfigName("Name")]
        public string Name { get; set; }

        [AppConfigName("number"), FileConfigName("Number")]
        public int Number { get; set; }

        [AppConfigName("weight"), FileConfigName("Weight")]
        public double Weight { get; set; }

        [AppConfigName("period"), FileConfigName("Period")]
        public TimeSpan Period { get; set; }
    }
}
