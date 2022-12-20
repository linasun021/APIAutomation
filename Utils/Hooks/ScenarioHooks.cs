using APIAutomation.Utils.Helper;
using APIAutomation.Utils.Settings;
using TechTalk.SpecFlow;

namespace APIAutomation.Utils.Hooks
{
    [Binding]
    public sealed class ScenarioHooks
    {

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            SettingsReader settingsReader = new SettingsReader();
            UrlHandler.baseUrl = settingsReader.GetBaseUrl();
        }
    }
}