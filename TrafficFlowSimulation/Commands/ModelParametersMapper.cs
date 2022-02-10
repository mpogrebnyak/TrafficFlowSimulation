using EvaluationKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
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
				n = 2,
				single_Vmax = 16.7,
				multiple_Vmax = string.Empty,
				a = 4,
				q = 3
			};

			return modelParametersModel;
		}

		public static ModelParametersModel MapMultiple(object parameters)
		{
			var modelParametersModel = (ModelParametersModel)parameters;

			var n = modelParametersModel.n;

			for (int i = 1; i <= n; i++)
			{
				modelParametersModel.multiple_Vmax += Mask(i, modelParametersModel.single_Vmax);
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
			var vMaxList = new List<double>();
			var lambdaList = new List<double>();

			switch (isAllCarsIdentical)
			{
				case IdenticalCars.Yes:
				{
					for (int i = 0; i < n; i++)
					{
						vMaxList.Add(modelParametersModel.single_Vmax);
						lambdaList.Add(-5 * i);
					}

					break;
				}
				case IdenticalCars.No:

					var vMaxDictionary = Parse(modelParametersModel.multiple_Vmax);
					
					for (int i = 0; i < n; i++)
					{
						if(vMaxDictionary.ContainsKey(i))
						{
							vMaxList.Add(vMaxDictionary[i]);
						}
						else
						{
							vMaxList.Add(modelParametersModel.single_Vmax);
						}
						lambdaList.Add(-5 * i);
					}

					break;
			}

			return new ModelParameters
			{
				n = n,
				Vmax = vMaxList.ToArray(),
				a = 4,
				q =3,
				tau = 1,
				Vmin = 0,
				L = 100,
				g = 9.8,
				mu = 0.6,
				k = 1,
				l = 3,
				p = 0.5,
				s = 20,
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
