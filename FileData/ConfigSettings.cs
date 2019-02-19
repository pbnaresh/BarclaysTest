using System;
using System.Collections.Specialized;
using System.Configuration;

namespace FileData
{
    internal class ConfigSettings : IConfigSettings
    {
        public string GetConfigValuesByKey(string configKey)
        {
            if (string.IsNullOrWhiteSpace(configKey))
                throw new ArgumentNullException("config key should not be empty");

            var applicationSettings = ConfigurationManager.AppSettings as NameValueCollection;
            return applicationSettings.Get(configKey);
        }
    }
}
