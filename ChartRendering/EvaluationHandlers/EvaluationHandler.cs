using System.IO;
using System.Threading;
using System.Windows.Forms;
using ChartRendering.ChartRenderModels;
using Common.Errors;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;

namespace ChartRendering.EvaluationHandlers;

public abstract class EvaluationHandler : IEvaluationHandler
{
	private static Thread? _thread;

	protected static object _lockObject;

	protected static bool _isPaused;

	public EvaluationHandler()
	{
		_lockObject = new object();
		_isPaused = false;
		_thread = null;
	}

	public void Execute(Form form, ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var parameters = new Parameters
		{
			Form = form,
			ModelParameters = modelParameters,
			ModeSettings = modeSettings
		};

		_thread = new Thread(RunEvaluation);
		_thread.Start(parameters);
	}

	public void ExecutePreCalculated(Form form, ModelParameters modelParameters, BaseSettingsModels modeSettings, object preCalculatedParameters)
	{
		var parameters = new Parameters
		{
			Form = form,ModelParameters = modelParameters,
			ModeSettings = modeSettings,
			PreCalculatedParameters = preCalculatedParameters
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

	protected virtual void EvaluatePreCalculated(object parameters)
	{
		throw new System.NotImplementedException();
	}

	public void StartExecution() 
	{
		lock (_lockObject) 
		{
			_isPaused = false;
		}
	}

	public void StopExecution()
	{
		lock (_lockObject) 
		{
			_isPaused = true;
		}
	}

	public void AbortExecution()
	{
		_thread?.Abort();
	}

	protected class Parameters
	{
		public Form Form;

		public ModelParameters ModelParameters;

		public BaseSettingsModels ModeSettings;

		public object PreCalculatedParameters;
	}
}