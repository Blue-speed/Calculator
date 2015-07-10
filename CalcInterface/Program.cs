using System;
using Calculator;

namespace CalcInterface
{
  class Program
  {
	static void Main(string[] args)
	{
	  Calc _calculator = new Calc();
	  string equation;
	  double lastResult = 0;

	  while (true)
	  {
		Console.WriteLine("Input your equation.");
		equation = Console.ReadLine().Trim();
		if (!_calculator.Operators.ContainsKey(equation[0]))
		  _calculator.Clear();
		_calculator.ParseString(equation);
		lastResult = _calculator.Result();
		Console.WriteLine("= " + lastResult.ToString());
	  }
	}
  }
}
