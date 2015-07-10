using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace Calculator_test
{
  [TestClass]
  public class ParseTests
  {
	Calc _calculator;

	[TestMethod]
	public void NoOperator()
	{
	  double value;
	  _calculator =  new Calc();
	  _calculator.Parse("5");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)5);
	}

	[TestMethod]
	public void DecimalValue()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.Parse("5.5");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)5.5);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentException))]
	public void NoOperatorMultipleValues()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.Parse("5");
	  _calculator.Parse("5");
	 value =  _calculator.Result();
	}

	[TestMethod]
	public void OperatorParsing()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.Parse("5");
	  _calculator.Parse("+");
	  _calculator.Parse("5");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)10);
	}

	[TestMethod]
	public void SimpleParseString()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.ParseString("5+5");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)10);
	}

	[TestMethod]
	public void ParseStringWithSpaces()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.ParseString("5 + 5");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)10);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentException))]
	public void NoOperatorParseString()
	{
	  _calculator = new Calc();
	  _calculator.ParseString("5 5");
	  _calculator.Result();
	}

	[TestMethod]
	public void ParseStringWithSimpleParse()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.ParseString("5 + ");
	  _calculator.Parse("5");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)10);
	}

  }
}
