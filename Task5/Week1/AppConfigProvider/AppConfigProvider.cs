using System.Configuration;

namespace AppConfigProvider
{
    public class AppConfigProvider : Providers.IConfigProvider
    {
        public string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                if (appSettings.AllKeys.Contains(key))
                    return appSettings[key];
            }
            catch (ConfigurationErrorsException e)
            {
                throw new ConfigurationErrorsException($"Error reading app setting {key}: \n {e.Message}. {e.InnerException.Message}");
            }
            return string.Empty;
        }

        public void WriteSetting(string settName, object SettValue)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                appSettings[settName] = SettValue.ToString();
            }
            catch (ConfigurationErrorsException e)
            {
                throw new ConfigurationErrorsException($"Error writing app setting {settName}: \n {e.Message}. {e.InnerException.Message}");
            }
        }
    }
}