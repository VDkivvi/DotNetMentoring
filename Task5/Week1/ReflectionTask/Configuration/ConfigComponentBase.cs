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

        Type AttributeType;
        public T Config;

        public ConfigComponent()
        {
            Config = new T();
            CollectProviders(PluginFolder);
        }

        private void CollectProviders(string folderPath)
        {
            var fileEntries = Directory.GetFiles(folderPath, "*Provider.dll");
            foreach (var entry in fileEntries)
            {
                if (!File.Exists(entry)) continue;

                var dllAssembly = Assembly.LoadFrom(entry);
                var providerTypeName = dllAssembly.DefinedTypes.First(t => t.GetInterfaces().Contains(typeof(IConfigProvider))).FullName;
                if (providerTypeName == null) continue; 

                var classType = dllAssembly.GetType(providerTypeName);
                if (classType == null) continue;

                var pluginInstance = Activator.CreateInstance(classType) as IConfigProvider;
                availableProviders.Add(pluginInstance);
            }
        }

        public ConfigComponent<T> Using<TAttr>()
        {
            var attributeType = typeof(TAttr);
            var attrName = attributeType.Name;

            //TODO: restrict attr types by type of configuration class
            if (!Config.GetType().GetProperties()
                .Any(prop => prop.GetCustomAttributes()
                    .Select(attr => attr.GetType()).Contains(attributeType)))
                throw new ArgumentException($"Any config property of class {typeof(T).Name} does not have {attributeType.Name} attribute");

            //TODO: dynamic config provider
            var possibleProv = availableProviders
                .Where(x => x.GetType().Name.ToLower()
                    .StartsWith(attrName.ToLower().Replace("confignameattribute", "")));
            if (possibleProv.Any())
                currentProvider = possibleProv.First();
            else
            {
                throw new ArgumentException(
                    $"No available config providers for attribute {attrName}. " +
                    $"Providers {string.Join(", ", availableProviders.Select(x => x.GetType().Name))}");
            }

            AttributeType = attributeType;
            return this;
        }

        public void SaveSettings(string settingName, object newValue)
        {
            currentProvider.WriteSetting(settingName, newValue);
            LoadSettings();
        }

        public void LoadSettings()
        {
            foreach (var prop in Config.GetType().GetProperties())
            {
                if (currentProvider == null)
                    throw new InvalidOperationException("Please, assign type of Attribute at least once");

                var attrs = prop.GetCustomAttribute(AttributeType, false);

                if (attrs == null) continue;
                var value = currentProvider.ReadSetting(((ConfigNameAttribute)attrs).Name);
                var newValue = TypeDescriptor.GetConverter(prop.PropertyType).ConvertFromString(value);
                prop.SetValue(Config, newValue);
            }
        }
    }


}
