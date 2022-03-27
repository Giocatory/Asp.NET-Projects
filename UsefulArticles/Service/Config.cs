using Newtonsoft.Json.Linq;
using System.Text;

namespace UsefulArticles.Service
{
    public class Config
    {
        public static string ConnectionString { get; set; } = (JObject.Parse(File.ReadAllText($"{Environment.CurrentDirectory}\\appsettings.json", Encoding.UTF8)))["ConnectionString"].Value<String>();
        public static string CompanyName { get; set; } = (JObject.Parse(File.ReadAllText($"{Environment.CurrentDirectory}\\appsettings.json", Encoding.UTF8)))["Project"]["CompanyName"].Value<String>();
        public static string CompanyPhone { get; set; } = (JObject.Parse(File.ReadAllText($"{Environment.CurrentDirectory}\\appsettings.json", Encoding.UTF8)))["Project"]["CompanyPhone"].Value<String>();
        public static string CompanyPhoneShort { get; set; } = (JObject.Parse(File.ReadAllText($"{Environment.CurrentDirectory}\\appsettings.json", Encoding.UTF8)))["Project"]["CompanyPhoneShort"].Value<String>();
        public static string CompanyEmail { get; set; } = (JObject.Parse(File.ReadAllText($"{Environment.CurrentDirectory}\\appsettings.json", Encoding.UTF8)))["Project"]["CompanyEmail"].Value<String>();
    }
}
