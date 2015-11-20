using System.Collections.Specialized;
using sc = System.Configuration;

namespace yesmarket.Configuration
{
    public class ConfigurationManagerImpl : IConfigurationManager
    {
        public NameValueCollection AppSettings => sc.ConfigurationManager.AppSettings;
        public sc.ConnectionStringSettingsCollection ConnectionStrings => sc.ConfigurationManager.ConnectionStrings;

        public object GetSection(string sectionName)
        {
            return sc.ConfigurationManager.GetSection(sectionName);
        }

        public void RefreshSection(string sectionName)
        {
            sc.ConfigurationManager.RefreshSection(sectionName);
        }

        public sc.Configuration OpenMachineConfiguration()
        {
            return sc.ConfigurationManager.OpenMachineConfiguration();
        }

        public sc.Configuration OpenMappedMachineConfiguration(sc.ConfigurationFileMap fileMap)
        {
            return sc.ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
        }

        public sc.Configuration OpenExeConfiguration(sc.ConfigurationUserLevel userLevel)
        {
            return sc.ConfigurationManager.OpenExeConfiguration(userLevel);
        }

        public sc.Configuration OpenExeConfiguration(string exePath)
        {
            return sc.ConfigurationManager.OpenExeConfiguration(exePath);
        }

        public sc.Configuration OpenMappedExeConfiguration(sc.ExeConfigurationFileMap fileMap,
            sc.ConfigurationUserLevel userLevel)
        {
            return sc.ConfigurationManager.OpenMappedExeConfiguration(fileMap, userLevel);
        }

        public sc.Configuration OpenMappedExeConfiguration(sc.ExeConfigurationFileMap fileMap,
            sc.ConfigurationUserLevel userLevel, bool preLoad)
        {
            return sc.ConfigurationManager.OpenMappedExeConfiguration(fileMap, userLevel, preLoad);
        }
    }
}