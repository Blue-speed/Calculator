
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;

namespace Calculator_test
{
  /// <summary>
  /// Summary description for SubtractionTests
  /// </summary>
  [TestClass]
  public class ComplexMathTests
  {

	Calc _calculator;

	[TestMethod]
	public void AdditionAndSubtraction()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.ParseString("5+5-3");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)7);
	}
	[TestMethod]
	public void MultiplyAndDivide()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.ParseString("5*4/2");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)10);
	}

	[TestMethod]
	public void AddAndMultiply()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.ParseString("1+2*2");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)5);
	  _calculator.Clear();
	  _calculator.ParseString("2*2+1");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)5);
	}
	[TestMethod]
	public void PowerAndMultiply()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.ParseString("2^3*2");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)16);
	  _calculator.Clear();
	  _calculator.ParseString("2*2^3");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)16);
	}
	[TestMethod]
	public void AllOperators()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.ParseString("1+3*2/4-5^2");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)-22.5);
	  _calculator.Clear();
	  _calculator.ParseString("8^2-4/2+3*4");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)74);
	}

  }
}
