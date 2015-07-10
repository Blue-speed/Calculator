using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace Calculator_test
{
  [TestClass]
  public class ParenTests
  {

	Calc _calculator;

	[TestMethod]
	public void SimpleParen()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.ParseString("(1+1)");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)2);
	}

	[TestMethod]
	public void ComplexParen()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.ParseString("2*(1+1)");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)4);
	}
  }
}
