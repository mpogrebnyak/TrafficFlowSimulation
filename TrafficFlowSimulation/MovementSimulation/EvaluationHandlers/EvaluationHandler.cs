using System.Threading;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation.MovementSimulation.EvaluationHandlers;

public abstract class EvaluationHandler : IEvaluationHandler
{
	protected static Thread _thread;

	protected static object _lockObject;

	protected static bool _isPaused;

	public EvaluationHandler()
	{
		_lockObject = new object();
		_isPaused = false;
		_thread = null;
	}

	public void Execute(AllChartsModel charts, ModelParameters modelParameters, ModeSettings modeSettings)
	{
		var parameters = new Parameters
		{
			Charts = charts,
			ModelParameters = modelParameters,
			ModeSettings = modeSettings
		};

		_thread = new Thread(Evaluate);
		_thread.Start(parameters);
	}

	protected abstract void Evaluate(object parameters);

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
		if (_thread != null)
			_thread.Abort();
	}

	protected class Parameters
	{
		public AllChartsModel Charts;
		public ModelParameters ModelParameters;
		public ModeSettings ModeSettings;
	}
}