using System;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.ParametersModels;
using TrafficFlowSimulation.Models.SettingsModels;
using TrafficFlowSimulation.Windows;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Services;

public static class DefaultParametersValuesService
{
	// Переделать регистрацию сервисов, этот сервис зарегистрировать 
	//DefaultParametersValuesService()
	//{
		
	//}
	public static ModelParameters GetDefaultModelParameters()
	{
		var modelParameters = new ModelParameters();

		GetBasicParametersModel().MapTo(modelParameters);
		GetAdditionalParametersModel().MapTo(modelParameters);
		GetInitialConditionsParametersModel().MapTo(modelParameters);

		GetStartAndStopMovementModeSettingsModel().MapTo(modelParameters);

		return modelParameters;
	}

	public static object GetDefaultEditModelParameters(Type modelType)
	{
		var instance = Activator.CreateInstance(modelType);

		switch (instance)
		{
			case BasicParametersModel:
				return GetBasicParametersModel();
			case AdditionalParametersModel:
				return GetAdditionalParametersModel();
			case InitialConditionsParametersModel:
				return GetInitialConditionsParametersModel();

			case StartAndStopMovementModeSettingsModel:
				return GetStartAndStopMovementModeSettingsModel();

			default:
				return instance;
		}
	}

	private static BasicParametersModel GetBasicParametersModel()
	{
		return new BasicParametersModel
		{
			IsCarsIdentical = new ComboboxItem
			{
				Text = IdenticalCars.No.GetDescription(),
				Value = IdenticalCars.No
			},
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

	private static AdditionalParametersModel GetAdditionalParametersModel()
	{
		return new AdditionalParametersModel
		{
			g = 9.8,
			mu = 0.6
		};
	}

	private static InitialConditionsParametersModel GetInitialConditionsParametersModel()
	{
		return new InitialConditionsParametersModel
		{
			lambda = 25,
			lambda_multiple = string.Empty,
			Vn = 0,
			Vn_multiple = string.Empty
		};
	}

	private static StartAndStopMovementModeSettingsModel GetStartAndStopMovementModeSettingsModel()
	{
		return new StartAndStopMovementModeSettingsModel
		{
			L = 200
		};
	}
}