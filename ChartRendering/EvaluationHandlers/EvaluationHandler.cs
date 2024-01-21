using System.IO;
using System.Threading;
using ChartRendering.ChartRenderModels;
using ChartRendering.Events;
using Common.Errors;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;

namespace ChartRendering.EvaluationHandlers;

public abstract class EvaluationHandler : IEvaluationHandler
{
	private static Thread? _thread;

	protected static object LockObject;

	protected static bool IsPaused;

	protected EvaluationHandler()
	{
		LockObject = new object();
		IsPaused = false;
		_thread = null;
	}

	public void Execute(ModelParameters modelParameters, BaseSettingsModels modeSettings, ChartEventHandler chartEventHandler)
	{
		var parameters = new Parameters
		{
			ModelParameters = modelParameters,
			ModeSettings = modeSettings,
			ChartEventHandler = chartEventHandler
		};

		_thread = new Thread(RunEvaluation);
		_thread.Start(parameters);
	}

	public void ExecutePreCalculated(ModelParameters modelParameters, BaseSettingsModels modeSettings, ChartEventHandler chartEventHandler, object preCalculatedParameters)
	{
		var parameters = new Parameters
		{
			ModelParameters = modelParameters,
			ModeSettings = modeSettings,
			PreCalculatedParameters = preCalculatedParameters,
			ChartEventHandler = chartEventHandler
		};

		_thread = new Thread(EvaluatePreCalculated);
		_thread.Start(parameters);
	}

	private void RunEvaluation(object parameters)
	{
		try
		{
			Evaluate(parameters);
		}
		catch (ParametersException e)
		{
			ServiceLocator.Current.GetInstance<IErrorManager>().Send(e.ParameterSender, new ErrorEventArgs(e));
		}
	}
	protected abstract void Evaluate(object parameters);

	protected virtual void EvaluatePreCalculated(object parameters) { }

	public void StartExecution() 
	{
		lock (LockObject) 
		{
			IsPaused = false;
		}
	}

	public void StopExecution()
	{
		lock (LockObject) 
		{
			IsPaused = true;
		}
	}

	public void AbortExecution()
	{
		_thread?.Abort();
	}

	public bool IsExecuted()
	{
		return _thread != null;
	}

	protected class Parameters
	{
		public ModelParameters ModelParameters;

		public BaseSettingsModels ModeSettings;

		public object PreCalculatedParameters;

		public ChartEventHandler ChartEventHandler;
	}
}