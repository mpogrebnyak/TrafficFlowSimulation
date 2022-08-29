using Microsoft.Practices.ServiceLocation;

namespace Common.Modularity;

public class Bootstrapper
{
	public virtual void Start()
	{
		var serviceRegistrator = new UnityServiceRegistrator();

		var locator = serviceRegistrator.CreateLocator();
		ServiceLocator.SetLocatorProvider(() => locator);
	}
}