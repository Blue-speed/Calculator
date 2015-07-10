
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;

namespace Calculator_test
{
  /// <summary>
  /// Summary description for SubtractionTests
  /// </summary>
  [TestClass]
  public class ExponentTests
  {

	Calc _calculator;

	[TestMethod]
	public void SimpleExponent()
	{
	  double value;
	  _calculator = new Calc();
	  _calculator.Parse("2");
	  _calculator.Parse("^");
	  _calculator.Parse("2");
	  value = _calculator.Result();
	  Assert.AreEqual(value, (double)4);
	}
  }
}
