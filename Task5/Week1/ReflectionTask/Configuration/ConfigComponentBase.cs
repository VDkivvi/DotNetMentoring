using Providers;
using ReflectionTask.Attributes;
using System.ComponentModel;
using System.Reflection;


namespace ReflectionTask.Configuration
{
    internal class ConfigComponent<T> where T : class, new()
    {
        //todo: to config
        const string PluginFolder = @"c:\Users\Valeriia_Danilova\source\repos\Mentoring\DotNet\Task5\Week1\ConfigProviders\";


        List<IConfigProvider> availableProviders = new();
        IConfigProvider currentProvider;
        T? conf;
        Type AttributeType;

        public T? Config => conf;

        public ConfigComponent()
        {
            CollectProviders(PluginFolder);
            //TODO: dynamic config provider
            currentProvider = new AppConfigProvider.AppConfigProvider();
        }

        void CollectProviders(string folderPath)
        {
            string[] fileEntries = Directory.GetFiles(folderPath, "*Provider.dll");
            foreach (string entry in fileEntries)
            {
                var dllAssembly = Assembly.LoadFrom(entry);
                var providerTypeName = dllAssembly.DefinedTypes.First(t => t.GetInterfaces().Contains(typeof(IConfigProvider))).FullName;
                Type classType = dllAssembly.GetType(providerTypeName);
                if (classType != null)
                {
                    var pluginInstance = Activator.CreateInstance(classType) as IConfigProvider;
                    availableProviders.Add(pluginInstance);
                }
            }
        }

        public ConfigComponent<T> Using<ATTR>()
        {
            AttributeType = typeof(ATTR);
            return this;
        }

        public void SaveSettings(string settingName, object newValue)
        {
            currentProvider.WriteSetting(settingName, newValue);
            LoadSettings();
        }

        public void LoadSettings()
        {
            var result = new T();

            foreach (var prop in result.GetType().GetProperties())
            {
                var attrs = prop.GetCustomAttribute(AttributeType, false);

                if (attrs != null)
                {
                    string value = currentProvider.ReadSetting(((ConfigNameAttribute)attrs).Name);
                    var newValue = TypeDescriptor.GetConverter(prop.PropertyType).ConvertFromString(value);
                    prop?.SetValue(result, newValue);
                }
            }
            conf = result;
        }
    }


}
