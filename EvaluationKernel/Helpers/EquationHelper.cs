using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationKernel.Models;

namespace EvaluationKernel.Helpers;

public static class EquationHelper
{
	public static int BinarySearchInDictionary(SortedDictionary<int, SegmentModel> dictionary, double x)
	{
		//var keys = dictionary.Keys.ToList();
		var left = 0;
		var right = dictionary.Keys.ToList().Count - 1;

		while (left < right)
		{
			var mid = left + (right - left) / 2;

			// ReSharper disable once CompareOfFloatsByEqualityOperator
			if (dictionary[mid].SegmentBeginning == x)
			{
				return mid; // Найдено значение с заданным SegmentBeginning
			}

			if (dictionary[mid].SegmentBeginning < x)
			{
				left = mid + 1;
			}
			else
			{
				right = mid - 1;
			}
		}

		//return -1; // Значение не найдено

		// Ключ не найден, возвращаем индекс, куда его следует вставить
		return left;
	}
}