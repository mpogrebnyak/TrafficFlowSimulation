using Common.Modularity;
using Microsoft.Practices.ServiceLocation;

namespace Common;

public static class CommonHelper
{
	public static IServiceRegistrator ServiceRegistration => ServiceLocator.Current.GetInstance<IServiceRegistrator>();
}