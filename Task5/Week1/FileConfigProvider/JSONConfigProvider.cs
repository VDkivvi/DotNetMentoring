using System.Text;
using Newtonsoft.Json.Linq;

namespace JSONConfigProvider
{
    public class JsonConfigProvider : Providers.IConfigProvider
    {
        private const string FilePath = "appsettings.json";

        public string ReadSetting(string setPath)
        {
            using var r = new StreamReader(FilePath);
            var json = JObject.Parse(r.ReadToEnd());
            var data = json.SelectToken(setPath);
            return (data != null ? data.Value<string>() : string.Empty) ?? string.Empty;
        }

        public void WriteSetting(string setPath, object setValue)
        {
            string jsonString;
            using (var fs = new StreamReader(FilePath))
            {
                var json = JObject.Parse(fs.ReadToEnd());
                var data = json.SelectToken(setPath);

                if (data != null)
                {
                    data.Replace(setValue.ToString());
                    jsonString = json.ToString();
                }
                else
                {
                    throw new ArgumentException($"No such property in the config file: {setPath}");
                }
                Console.WriteLine(json.ToString());
            }

            using (var fs = new FileStream(FilePath, FileMode.Create))
            {
                fs.Write(Encoding.UTF8.GetBytes(jsonString));
            }
        }
    }
}