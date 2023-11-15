namespace Providers
{
    public interface IConfigProvider
    {
        public string ReadSetting(string settName);
        public void WriteSetting(string settName, object SettValue);
    }
}
