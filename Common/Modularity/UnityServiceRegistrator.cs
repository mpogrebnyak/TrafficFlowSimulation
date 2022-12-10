using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Common.Modularity;

public interface IServiceRegistrator
{
	IServiceLocator CreateLocator();

	void RegisterInstance<TInterface>(Type serviceType, string name = null, bool skipIfAlreadyRegistered = true);

	void RegisterInstance(Type interfaceType, Type serviceType, string name = null, bool skipIfAlreadyRegistered = true);

	void RegisterInstance<TInterface, TServiceType>(string name = null, bool skipIfAlreadyRegistered = true)
		where TServiceType : TInterface;

	TInterface RegisterInstance<TInterface>(Func<TInterface> createInstance, string name = null, bool skipIfAlreadyRegistered = true);

	object RegisterInstance(Type interfaceType, Func<object> createInstance, string name = null, bool skipIfAlreadyRegistered = true);

	void RegisterType<TInterface, TType>(string name = null, bool skipIfAlreadyRegistered = true) where TType : TInterface;

	void RegisterType(Type interfaceType, Type serviceType, string name = null, bool skipIfAlreadyRegistered = true);

	bool IsRegistered<TInterface>(string name = null);

	bool IsRegistered(Type interfaceType, string name = null);
}

public class UnityServiceRegistrator : IServiceRegistrator
{
	public UnityServiceRegistrator()
	{
		Container = new UnityContainer();
		Container.RegisterInstance<IServiceRegistrator>(this);
	}

	public IUnityContainer Container { get; private set; }

	public IServiceLocator CreateLocator()
	{
		return new UnityServiceLocator(Container);
	}

	public void RegisterInstance<TInterface>(Type serviceType, string name = null, bool skipIfAlreadyRegistered = true)
	{
		if (skipIfAlreadyRegistered && IsRegistered(typeof(TInterface), name)) return;

		Container.RegisterType(typeof(TInterface), serviceType, name, new ContainerControlledLifetimeManager());
	}

	public void RegisterInstance(Type interfaceType, Type serviceType, string name = null, bool skipIfAlreadyRegistered = true)
	{
		if (skipIfAlreadyRegistered && IsRegistered(interfaceType, name)) return;

		Container.RegisterType(interfaceType, serviceType, name, new ContainerControlledLifetimeManager());
	}

	public void RegisterInstance<TInterface, TServiceType>(string name = null, bool skipIfAlreadyRegistered = true)
		where TServiceType : TInterface
	{
		RegisterInstance<TInterface>(typeof(TServiceType), name, skipIfAlreadyRegistered);
	}

	public TInterface RegisterInstance<TInterface>(Func<TInterface> createInstance, string name = null, bool skipIfAlreadyRegistered = true)
	{
		return (TInterface) RegisterInstance(typeof(TInterface), () => createInstance(), name, skipIfAlreadyRegistered);
	}

	public object RegisterInstance(Type interfaceType, Func<object> createInstance, string name = null, bool skipIfAlreadyRegistered = true)
	{
		if (skipIfAlreadyRegistered && IsRegistered(interfaceType, name))
		{
			return Container.Resolve(interfaceType, name);
		}

		var instance = createInstance();

		Container.RegisterInstance(interfaceType, name, instance);
		return instance;
	}

	public void RegisterType<TInterface, TType>(string name = null, bool skipIfAlreadyRegistered = true)
		where TType : TInterface
	{
		RegisterType(typeof(TInterface), typeof(TType), name, skipIfAlreadyRegistered);
	}

	public void RegisterType(Type interfaceType, Type serviceType, string name = null, bool skipIfAlreadyRegistered = true)
	{
		if (skipIfAlreadyRegistered && IsRegistered(interfaceType, name))
			return;
		Container.RegisterType(interfaceType, serviceType, name);
	}

	public bool IsRegistered<TInterface>(string name = null)
	{
		return IsRegistered(typeof(TInterface), name);
	}

	public bool IsRegistered(Type interfaceType, string? name = null)
	{
		return name == null
			? Container.IsRegistered(interfaceType)
			: Container.IsRegistered(interfaceType, name);
	}
}
