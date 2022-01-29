using EvaluationKernel.Models;
using System;
using System.Collections.Generic;

namespace TrafficFlowSimulation.Commands
{
    public static class ModelParametersMapper
    {
        public static ModelParameters MapModel(Object parameters, out List<string> errors)
        {
            errors = new List<string>();
            var modelParameters = (ModelParameters)parameters;

            modelParameters.tau = 1;
            modelParameters.Vmin = 0;

            var lambda = new List<double>();
            for (var i = 0; i <= modelParameters.n; i++) 
            {
                lambda.Add(-5 * i);
            }

            modelParameters.lambda = lambda.ToArray();
            modelParameters.L = 100;
            modelParameters.g = 9.8;
            modelParameters.mu = 0.6;
            modelParameters.k = 1;
            modelParameters.l = 3;
            modelParameters.p = 0.5;
            modelParameters.s = 20;

            return modelParameters;
        }
    }
}
