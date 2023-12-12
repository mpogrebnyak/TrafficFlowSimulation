using ChartRendering.Configurations;
using ChartRendering.Properties;
using Common.Modularity;
using Localization;
using Localization.Localization;

namespace ChartRendering;

public class ChartRenderingModule : IInitializable
{
	public void Initialize()
	{
		var handlersConfiguration = new HandlersConfiguration();
		handlersConfiguration.Initialize();

		var modelsConfiguration = new ModelsConfiguration();
		modelsConfiguration.Initialize();

		var chartResourcesProvider = new ResourceProvider(typeof(ChartRenderingResources));
		LocalizationHelper.Register(chartResourcesProvider);
	}
}