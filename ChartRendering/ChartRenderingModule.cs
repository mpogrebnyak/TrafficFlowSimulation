using ChartRendering.Configurations;
using Common.Modularity;

namespace ChartRendering;

public class ChartRenderingModule : IInitializable
{
	public void Initialize()
	{
		var handlersConfiguration = new HandlersConfiguration();
		handlersConfiguration.Initialize();

		var modelsConfiguration = new ModelsConfiguration();
		modelsConfiguration.Initialize();
	}
}