using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
namespace FileData
{
    internal class ConfigSettings : IConfigSettings
    {
        public string[] GetConfigValuesByKey(string configKey)
        {
            if (string.IsNullOrWhiteSpace(configKey))
                throw new ArgumentNullException("config key should not be empty");

            var applicationSettings = ConfigurationManager.AppSettings as NameValueCollection;
            var formats = applicationSettings.Get(configKey).Split(',').Select(email => email.Trim()).ToArray();
            if (formats.Length == 0)
                throw new Exception("no formats found in config");
            
            return formats;
        }
      
    }
}
