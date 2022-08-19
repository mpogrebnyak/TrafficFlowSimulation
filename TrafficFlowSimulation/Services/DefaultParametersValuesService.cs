using System;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.ParametersModels;
using TrafficFlowSimulation.Models.ParametersModels.Constants;
using TrafficFlowSimulation.Models.SettingsModels;
using TrafficFlowSimulation.Models.SettingsModels.Constants;
using TrafficFlowSimulation.Windows;
using TrafficFlowSimulation.Windows.CustomControls;

namespace TrafficFlowSimulation.Services;

public interface IDefaultParametersValuesService
{
	ModelParameters GetDefaultModelParameters();

	object GetDefaultEditModelParameters(Type modelType);
}

public class DefaultParametersValuesService : IDefaultParametersValuesService
{
	public ModelParameters GetDefaultModelParameters()
	{
		var modelParameters = new ModelParameters();

		GetBasicParametersModel().MapTo(modelParameters);
		GetAdditionalParametersModel().MapTo(modelParameters);
		GetInitialConditionsParametersModel().MapTo(modelParameters);

		GetStartAndStopMovementModeSettingsModel().MapTo(modelParameters);

		return modelParameters;
	}

	public object GetDefaultEditModelParameters(Type modelType)
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
			case MovementThroughOneTrafficLightModeSettingsModel:
				return GetMovementThroughOneTrafficLightModeSettingsModel();
			case InliningInFlowModeSettingsModel:
				return GetInliningInFlowModeSettingsModel();

			default:
				throw new InvalidOperationException();
		}
	}

	private BasicParametersModel GetBasicParametersModel()
	{
		return new BasicParametersModel
		{
			IsCarsIdentical = new ComboBoxItem
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

	private AdditionalParametersModel GetAdditionalParametersModel()
	{
		return new AdditionalParametersModel
		{
			g = 9.8,
			mu = 0.6
		};
	}

	private InitialConditionsParametersModel GetInitialConditionsParametersModel()
	{
		return new InitialConditionsParametersModel
		{
			lambda = 25,
			lambda_multiple = string.Empty,
			Vn = 0,
			Vn_multiple = string.Empty
		};
	}

	private StartAndStopMovementModeSettingsModel GetStartAndStopMovementModeSettingsModel()
	{
		return new StartAndStopMovementModeSettingsModel
		{
			L = 200
		};
	}

	private MovementThroughOneTrafficLightModeSettingsModel GetMovementThroughOneTrafficLightModeSettingsModel()
	{
		return new MovementThroughOneTrafficLightModeSettingsModel
		{
			L = 10000,
			FirstTrafficLightColor = new ComboBoxItem
			{
				Text = FirstTrafficLightColor.Green.GetDescription(),
				Value = FirstTrafficLightColor.Green
			},
			SingleLightGreenTime = 10,
			SingleLightRedTime = 20
		};
	}

	private InliningInFlowModeSettingsModel GetInliningInFlowModeSettingsModel()
	{
		return new InliningInFlowModeSettingsModel
		{
			L = 10000
		};
	}
}