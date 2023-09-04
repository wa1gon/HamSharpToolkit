using System.Configuration;

namespace HamSharpToolkit.HamUtils.Configuration
{
    public class GetConfiguationItem
    {
        public string GetPreferredLanguage(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}