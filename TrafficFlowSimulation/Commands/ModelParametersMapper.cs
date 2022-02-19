using EvaluationKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Commands
{
	public static class ModelParametersMapper
	{
		private static readonly char _separator = '-';
		private static readonly char _elementsSeparator = ' ';

		public static ModelParametersModel GetDefaultParameters()
		{
			var modelParametersModel = new ModelParametersModel
			{
				Lenght = 100,
				n = 3,
				Vmax = 16.7,
				Vmax_multiple = string.Empty,
				tau = 1,
				tau_multiple = string.Empty,
				a = 4,
				a_multiple = string.Empty,
				q = 3,
				q_multiple = string.Empty,
				l = 4,
				l_multiple = string.Empty,
				k = 0.5,
				k_multiple = string.Empty,
				s = 20,
				s_multiple = string.Empty,
				g = 9.8,
				mu = 0.6
			};

			return modelParametersModel;
		}

		public static ModelParametersModel MapMultiple(object parameters)
		{
			var modelParametersModel = (ModelParametersModel)parameters;

			var n = modelParametersModel.n;

			for (int i = 1; i <= n; i++)
			{
				modelParametersModel.Vmax_multiple += Mask(i, modelParametersModel.Vmax);
				modelParametersModel.tau_multiple += Mask(i, modelParametersModel.tau);
				modelParametersModel.a_multiple += Mask(i, modelParametersModel.a);
				modelParametersModel.q_multiple += Mask(i, modelParametersModel.q);
				modelParametersModel.l_multiple += Mask(i, modelParametersModel.l);
				modelParametersModel.k_multiple += Mask(i, modelParametersModel.k);
				modelParametersModel.s_multiple += Mask(i, modelParametersModel.s);
			}

			return modelParametersModel;
		}

		private static string Mask(int i, double param)
		{
			return string.Format("{0}-{1}" + _elementsSeparator, i, param);
		}

		public static ModelParameters MapModel(Object parameters, IdenticalCars isAllCarsIdentical)
		{
			var modelParametersModel = (ModelParametersModel)parameters;

			var n = modelParametersModel.n;
			var tau = modelParametersModel.tau;
			var L = modelParametersModel.Lenght;

			var g = modelParametersModel.g;
			var mu = modelParametersModel.mu;

			var vMaxList = new List<double>();
			var aList = new List<double>();
			var qList = new List<double>();
			var lList = new List<double>();
			var kList = new List<double>();
			var sList = new List<double>();
			var lambdaList = new List<double>();

			switch (isAllCarsIdentical)
			{
				case IdenticalCars.Yes:
				{
					for (int i = 0; i < n; i++)
					{
						vMaxList.Add(modelParametersModel.Vmax);
						aList.Add(modelParametersModel.a);
						qList.Add(modelParametersModel.q);
						lList.Add(modelParametersModel.l);
						kList.Add(modelParametersModel.k);
						sList.Add(modelParametersModel.s);
						lambdaList.Add(-5 * i);
					}

					break;
				}
				case IdenticalCars.No:

					var vMaxDictionary = Parse(modelParametersModel.Vmax_multiple);
					var aDictionary = Parse(modelParametersModel.a_multiple);
					var qDictionary = Parse(modelParametersModel.q_multiple);
					var lDictionary = Parse(modelParametersModel.l_multiple);
					var kDictionary = Parse(modelParametersModel.k_multiple);
					var sDictionary = Parse(modelParametersModel.k_multiple);

					for (int i = 0; i < n; i++)
					{
						vMaxList.Add(vMaxDictionary.ContainsKey(i) 
							? vMaxDictionary[i] 
							: modelParametersModel.Vmax);

						aList.Add(aDictionary.ContainsKey(i) 
							? aDictionary[i] 
							: modelParametersModel.a);

						qList.Add(qDictionary.ContainsKey(i) 
							? qDictionary[i] 
							: modelParametersModel.q);

						lList.Add(lDictionary.ContainsKey(i)
							? lDictionary[i]
							: modelParametersModel.l);

						kList.Add(kDictionary.ContainsKey(i)
							? kDictionary[i]
							: modelParametersModel.k);

						sList.Add(sDictionary.ContainsKey(i)
							? sDictionary[i]
							: modelParametersModel.s);

						lambdaList.Add(-15 * i);
					}

					break;
			}

			return new ModelParameters
			{
				n = n,
				Vmax = vMaxList.ToArray(),
				a = aList.ToArray(),
				q = qList.ToArray(),
				l = lList.ToArray(),
				tau = tau,
				Vmin = 0,
				L = L,
				g = g,
				mu = mu,
				eps = 1,
				k = kList.ToArray(),
				s = sList.ToArray(),
				lambda = lambdaList.ToArray()
			}; 
		}

		private static Dictionary<int, double> Parse(string str)
		{
			var dictionary = new Dictionary<int, double>();
			var elements = str
				.Trim()
				.Split(_elementsSeparator)
				.ToList();

			foreach (var element in elements)
			{
				var value = element.Split(_separator);
				dictionary.Add(Convert.ToInt32(value[0]) - 1, Convert.ToDouble(value[1]));
			}

			return dictionary;
		}
	}
}
