using ReflectionTask.Attributes;

namespace ReflectionTask.POCO
{
    public record EnvConfig
    {
        [SystemEnvName("JAVA_HOME")]
        public string JavaHome { get; }

        [SystemEnvName("BUILD_NUMBER")]
        public string LastBuildNumber { get; }
    }
}
