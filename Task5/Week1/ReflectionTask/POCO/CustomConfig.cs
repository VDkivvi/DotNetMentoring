using ReflectionTask.Attributes;


namespace ReflectionTask.POCO
{
    public record CustomConfig
    {
        [AppConfigName("build"), JsonConfigName("configuration.lastBuildNumber")]
        public int LastBuildNumber { get; set; }

        [AppConfigName("name"), JsonConfigName("configuration.name")]
        public string Name { get; set; }

        [AppConfigName("number"), JsonConfigName("configuration.number")]
        public int Number { get; set; }

        [AppConfigName("weight"), JsonConfigName("configuration.weight")]
        public double Weight { get; set; }

        [AppConfigName("period"), JsonConfigName("configuration.period")]
        public TimeSpan Period { get; set; }
    }
}
