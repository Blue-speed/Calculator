
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;

namespace Calculator_test
{
  /// <summary>
  /// Summary description for SubtractionTests
  /// </summary>
  [TestClass]
  public class SubtractionTests
  {

	Calc _calculator;

	[TestMethod]
	public void SimpleSubtraction()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.Parse("5");
	  _calculator.Parse("-");
	  _calculator.Parse("5");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)0);
	}

	[TestMethod]
	public void ComplexSubtraction()
	{
	  double value;
	  double expected = 0;
	  _calculator = new Calc();
	  _calculator.Parse("0");
	  for (double i = 1.5; i < 100; i++)
	  {
		_calculator.Parse("-");
		expected = expected - i;
		_calculator.Parse(i.ToString());
	  }
	  value = _calculator.Result();
	  Assert.AreEqual(value, expected);
	}
  }
}
