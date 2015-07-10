using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace Calculator_test
{
  [TestClass]
  public class AdditionTests
  {

	Calc _calculator;

	[TestMethod]
	public void SimpleAddition()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.ParseString("1+1");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)2);
	}

	[TestMethod]
	public void ComplexAddition()
	{
	  double value;
	  double expected = 0;
	  _calculator = new Calc();
	  _calculator.Parse("0");
	  for (double i = 1.5; i < 1000; i++)
	  {
		expected = expected + i;
		_calculator.Parse("+");
		_calculator.Parse(i.ToString());
	  }
	  value = _calculator.Result();
	  Assert.AreEqual(value, expected);
	}

	[TestMethod]
	[ExpectedException(typeof(OverflowException))]
	public void ArithmicOverflow()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.Parse(double.MaxValue.ToString("R"));
	  _calculator.Parse("+");
	  _calculator.Parse(double.MaxValue.ToString("R"));
	  value = _calculator.Result();
	}
  }
}
