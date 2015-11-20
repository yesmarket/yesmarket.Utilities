using System.Collections.Specialized;
using sc = System.Configuration;

namespace yesmarket.Configuration
{
    public interface IConfigurationManager
    {
        NameValueCollection AppSettings { get; }
        sc.ConnectionStringSettingsCollection ConnectionStrings { get; }
        object GetSection(string sectionName);
        void RefreshSection(string sectionName);
        sc.Configuration OpenMachineConfiguration();
        sc.Configuration OpenMappedMachineConfiguration(sc.ConfigurationFileMap fileMap);
        sc.Configuration OpenExeConfiguration(sc.ConfigurationUserLevel userLevel);
        sc.Configuration OpenExeConfiguration(string exePath);

        sc.Configuration OpenMappedExeConfiguration(sc.ExeConfigurationFileMap fileMap,
            sc.ConfigurationUserLevel userLevel);

        sc.Configuration OpenMappedExeConfiguration(sc.ExeConfigurationFileMap fileMap,
            sc.ConfigurationUserLevel userLevel, bool preLoad);
    }
}