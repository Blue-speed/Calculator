using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Calculator
{
  /// <summary>
  /// Takes string input in infix or prefix notation 
  /// </summary>
  public class Calc 
  {
	private Queue<PostfixValue> _postfix;
	private Stack<char> _operators;
	public Dictionary<char,int> Operators;

	public Calc()
	{
	  _postfix = new Queue<PostfixValue>();
	  _operators = new Stack<char>();
	  Operators = new Dictionary<char,int>(){ { '-', 0}, { '+', 0 }, { '/', 1 }, { '*', 1 }, { '^', 2 } };
	}
	/// <summary>
	/// Parses input string into values and operators to be evaluated
	/// </summary>
	/// <param name="input">A string consisting of double values seperated by operators. Whitespace is acceptable.</param>
	public void ParseString(string input)
	{
	  List<string> values;
	  string splitPatern = @"([\+\-\*\/\^])|(\w+)";
	  values = new List<string>(Regex.Split(input, splitPatern));
	  values.RemoveAll(str => String.IsNullOrWhiteSpace(str));
	  foreach(var value in values)
	  {
		Parse(value);
	  }
	}
	/// <summary>
	/// Parses a single value or operator into the calculator
	/// </summary>
	/// <param name="value">A single double value or operator</param>
	public void Parse(string value)
	{
	  value = value.Trim();
	  double number;
	  char op;

	  //If its a number add to the Deque
	  if (double.TryParse(value, out number))
	  {
		_postfix.Enqueue(new PostfixValue(number));
	  } else {
		//Its not a number so verify its only a single character
		if (value.Length > 1)
		  throw new ArgumentException("Multiple operators in sequence found");
		op = value[0];

		if (!Operators.ContainsKey(op))
		  throw new ArgumentException("Invalid operator found");


		while (_operators.Count > 0 && Operators[_operators.Peek()] >= Operators[op]) {
		  _postfix.Enqueue(new PostfixValue(_operators.Pop()));
		}
		_operators.Push(op);
      }
	}
	/// <summary>
	/// Evaluates the stored equations. Keeping the result in memory
	/// </summary>
	/// <returns>Returns the result of the stored equations.</returns>
	public double Result()
	{
	  while(_operators.Count > 0)
		_postfix.Enqueue(new PostfixValue(_operators.Pop())); // clear the stack
	  Eval();
	  return _postfix.Peek().Value();
	}

	/// <summary>
	/// Clears the memory
	/// </summary>
	public void Clear()
	{
	  _postfix.Clear();
	  _operators.Clear();
	}
	
	private void Eval()
	{
	  Stack<double> values = new Stack<double>();
	  PostfixValue value;

	  while(_postfix.Count > 0){
		value = _postfix.Dequeue();
		if (value.IsNumeric())
		{
		  values.Push(value.Value());
		}
		else
		{
		  switch (value.Operator())
		  {
			case '+':
			  values.AddInPlace();
			  break;
			case '-':
			  values.SubtractInPlace();
			  break;
			case '/':
			  values.DivideInPlace();
			  break;
			case '*':
			  values.MultiplyInPlace();
			  break;
			case '^':
			  values.PowInPlace();
			  break;
		  }
		}
	  }
	  if (values.Count > 1)
		throw new ArgumentException("Too many values");
	  _postfix.Enqueue(new PostfixValue(values.Pop()));
	}
  }

 class PostfixValue
  {
	private double? _value;
	private char? _operator;

	public PostfixValue(char Operator)
	{
	  _operator = Operator;
    }

	public PostfixValue(double value)
	{
	  _value = value;
	}

	public bool IsNumeric()
	{
	  if (_value.HasValue)
		return true;
	  return false;
	}

	public char Operator()
	{
	  if (!_operator.HasValue)
		throw new NullReferenceException();
	  return _operator.Value;
	}

	public double Value()
	{
	  if (!_value.HasValue)
		throw new NullReferenceException();
	  return _value.Value;
	}

  }

  /// <summary>
  /// The stack does not contain enough values to preform an operation.
  /// </summary>
  [Serializable]
  public class StackUnderflowException : Exception, ISerializable
  {
	public StackUnderflowException() { }

	public StackUnderflowException(string message) : base(message) { }

	public StackUnderflowException(string message, Exception inner) : base(message, inner) { }

	// This constructor is needed for serialization.
	protected StackUnderflowException(SerializationInfo info, StreamingContext context) : base(info, context) { }
  }
}
