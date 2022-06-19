using System;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation.Services;

public static class DefaultParametersValuesService
{
	// Переделать регистрацию сервисов, этот сервис зарегистрировать 
	//DefaultParametersValuesService()
	//{
		
	//}

	public static object GetDefaultEditBasicModelParameters(Type modelType)
	{
		var instance = Activator.CreateInstance(modelType);

		if (instance is EditBasicModelParameters)
		{
			return new EditBasicModelParameters
			{
				n = 2,
				Vmax = 16.7,
				Vmax_multiple = string.Empty,
				tau = 1,
				tau_multiple = string.Empty,
				a = 4,
				a_multiple = string.Empty,
				q = 3,
				q_multiple = string.Empty,
				l_safe = 5,
				l_safe_multiple = string.Empty,
				k = 0.5,
				k_multiple = string.Empty,
				s = 20,
				s_multiple = string.Empty,
			};
		}

		if (instance is EditAdditionalModelParameters)
		{
			return new EditAdditionalModelParameters
			{
				g = 9.8,
				mu = 0.6
			};
		}
		
		if (instance is EditInitialConditionsModelParameters)
		{
			return new EditInitialConditionsModelParameters
			{
				lambda = 25,
				lambda_multiple = string.Empty,
				Vn = 0,
				Vn_multiple = string.Empty
			};
		}

		return instance;
	}
}