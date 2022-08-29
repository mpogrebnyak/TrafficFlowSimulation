using Common.Modularity;
using Microsoft.Practices.ServiceLocation;

namespace Common;

public static class CommonHelper
{
	public static IServiceRegistrator ServiceRegistrator
	{
		get { return ServiceLocator.Current.GetInstance<IServiceRegistrator>(); }
	}
}