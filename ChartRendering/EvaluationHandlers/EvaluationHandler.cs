using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using ChartRendering.ChartRenderModels;
using ChartRendering.Events;
using Common.Errors;
using EvaluationKernel;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;

namespace ChartRendering.EvaluationHandlers;

public abstract class EvaluationHandler : IEvaluationHandler
{
	protected static KernelEvaluationHandler KernelEvaluationHandler;

	private static Thread? _thread;

	private static object _lockObject;

	private static bool _isPaused;

	protected EvaluationHandler()
	{
		_lockObject = new object();
		_isPaused = false;
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

		_thread = new Thread(EvaluateInternal);
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

	private void EvaluateInternal(object parameters)
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

	protected virtual void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		KernelEvaluationHandler = CreateKernelEvaluationHandler(p.ModelParameters, p.ModeSettings);

		StartExecution();

		var stopwatch = new Stopwatch();
		stopwatch.Start();

		while (true)
		{
			lock (_lockObject)
			{
				if (_isPaused)
				{
					Thread.Sleep(1000);
					continue;
				}
			}
			KernelEvaluationHandler.Next();
			AdditionalEvaluation(KernelEvaluationHandler.GetT(), KernelEvaluationHandler.GetX(), KernelEvaluationHandler.GetY());

			if (stopwatch.ElapsedMilliseconds >= 20)//p.ModelParameters.n)
			{
				SendEvent(
					p.ChartEventHandler,
					KernelEvaluationHandler.GetT(),
					KernelEvaluationHandler.GetX(),
					KernelEvaluationHandler.GetY());

				stopwatch.Restart();
			}
		}
	}

	protected virtual KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels) { return null; }

	protected virtual void SendEvent(ChartEventHandler eventHandler, double t, List<double> x, List<double> y) { }

	protected virtual void AdditionalEvaluation(double t, List<double> x, List<double> y) { }

	protected virtual void EvaluatePreCalculated(object parameters) { }

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