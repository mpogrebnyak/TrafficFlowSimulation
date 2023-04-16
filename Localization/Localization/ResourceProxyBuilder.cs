using Castle.DynamicProxy;

namespace Localization.Localization;

public static class ResourceProxyBuilder
{
	private class Interceptor : IInterceptor
	{
		private readonly Dictionary<string, string> _propValues;

		public Interceptor(Dictionary<string, string> propValues)
		{
			_propValues = propValues;
		}

		public void Intercept(IInvocation invocation)
		{
			if (invocation.Method.Name.StartsWith("set_", StringComparison.Ordinal))
				return;

			string desiredPropertyKey = null;
			if (invocation.Method.Name.StartsWith("get_", StringComparison.Ordinal))
				desiredPropertyKey = invocation.Method.Name.Remove(0, 4);
			else
				desiredPropertyKey = invocation.Method.Name;

			if (_propValues.ContainsKey(desiredPropertyKey))
			{
				var value = _propValues[desiredPropertyKey];
				if (value != null)
				{
					var methodParams = invocation.Method.GetParameters();
					var resultData = new Dictionary<string, object>();
					for (var i = 0; i < methodParams.Length; i++)
						resultData[methodParams[i].Name] = invocation.Arguments[i];
					value = NamedParametersFormatter.Format(value, resultData);
				}

				invocation.ReturnValue = value;
			}
			else
			{
				invocation.Proceed();
			}
		}
	}

	public static object Build(Type baseType, Dictionary<string, string> propValues)
	{
		var generator = new ProxyGenerator();
		return generator.CreateClassProxy(baseType, new Interceptor(propValues));
	}
}