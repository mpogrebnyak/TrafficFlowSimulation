using Common.Modularity;
using Microsoft.Practices.ServiceLocation;

namespace Common;

public static class CommonHelper
{
	public static IServiceRegistrator ServiceRegistration => ServiceLocator.Current.GetInstance<IServiceRegistrator>();

	public static DateTime GetDate => DateTime.Today;

	public static TimeSpan GetTime = DateTime.Now.TimeOfDay;
}