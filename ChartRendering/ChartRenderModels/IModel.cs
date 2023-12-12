using EvaluationKernel.Models;

namespace ChartRendering.ChartRenderModels;

/*
	При длинном названии парметра явно проставлять \n в месте переноса строки
*/

public interface IModel
{
	object GetDefault();

	void MapTo(ModelParameters mp);
}