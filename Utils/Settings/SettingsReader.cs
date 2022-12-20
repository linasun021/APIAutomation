using APIAutomation.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomation.Utils.Settings
{
    public class SettingsReader
    {
        public SettingInfo settingInfo;
        public SettingsReader() 
        {
            settingInfo = ContentHandler.ParseJson<SettingInfo>("Specflow.json");
        }
        public ExcuteEnv GetEnvironment()
        {
            return (ExcuteEnv)Enum.Parse(typeof(ExcuteEnv), settingInfo.Environment);
        }
        public string GetBaseUrl()
        {
            switch (this.GetEnvironment())
            {
                case ExcuteEnv.SIT:
                    return settingInfo.SITBaseUrl;
                case ExcuteEnv.UAT:
                    return settingInfo.UATBaseUrl;
                default:
                    return settingInfo.TestBaseUrl;
            }
        }
    }
}
