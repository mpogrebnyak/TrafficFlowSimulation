using Localization;
using System.Windows.Forms;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Resources;

namespace TrafficFlowSimulation.Commands
{
    public static class LocalizationHelper
    {
        private static ResourceBuilder ResourceBuilder;

        private static LocalizationComponentsModel LocalizationComponents;

        public static void InitializeResource(LocalizationComponentsModel lc)
        {
            LocalizationComponents = lc;

            var menuResourcesProvider = new ResourceProvider(typeof(MenuResources));
            var parametersResourcesProvider = new ResourceProvider(typeof(ParametersResources));

            var resourceManager = new ResourceManager(); 
            resourceManager.Register(menuResourcesProvider);
            resourceManager.Register(parametersResourcesProvider);

            ResourceBuilder = new ResourceBuilder(resourceManager);
        }

        public static void Translate()
        {
            var lc = LocalizationComponents;
            lc.LanguagesSwitcherButton.Text = ResourceBuilder.Get<MenuResources>().LanguagesSwitcheButtomTitle;
            lc.StartToolStripButton.Text = ResourceBuilder.Get<MenuResources>().StartButtonTitle;

            lc.LocalizationBinding.DataSource = new ParametersResources
            {
                ParametersTitle = ResourceBuilder.Get<ParametersResources>().ParametersTitle
            };
        }
    }
}
