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
	private static KernelEvaluationHandler _kernelEvaluationHandler;

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
		_kernelEvaluationHandler = CreateKernelEvaluationHandler(p.ModelParameters, p.ModeSettings);

		StartExecution();

		var stopwatch = new Stopwatch();
		stopwatch.Start();

		while (true)
		{
			lock (LockObject)
			{
				if (IsPaused)
				{
					Thread.Sleep(1000);
					continue;
				}
			}
			_kernelEvaluationHandler.Next();
			AdditionalEvaluation(_kernelEvaluationHandler.GetT(), _kernelEvaluationHandler.GetX(), _kernelEvaluationHandler.GetY());

			if (stopwatch.ElapsedMilliseconds >= 10 * p.ModelParameters.n / 2)
			{
				SendEvent(
					p.ChartEventHandler,
					_kernelEvaluationHandler.GetT(),
					_kernelEvaluationHandler.GetX(),
					_kernelEvaluationHandler.GetY());

				stopwatch.Restart();
			}
		}
	}

	protected abstract KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels);

	protected abstract void SendEvent(ChartEventHandler eventHandler, double t, List<double> x, List<double> y);

	protected virtual void AdditionalEvaluation(double t, List<double> x, List<double> y) { }

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