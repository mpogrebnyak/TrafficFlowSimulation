using Common.Modularity;
using Microsoft.Practices.ServiceLocation;

namespace Common;

public static class CommonHelper
{
	public static IServiceRegistrator ServiceRegistration
	{
		get { return ServiceLocator.Current.GetInstance<IServiceRegistrator>(); }
	}
}