# Calculator

Create a calculator function that takes a single string of input that includes numbers and operators and returns the numeric result of the equation.

Don’t forget input validation, error handling (divide by zero), and operator precedence concerns!

Examples:

- A string of "5+5+32" returns 42 as an integer

- A string of "3 * 4" returns 12 as an integer

You can add as much (or little -- your call) to it as you would like (console app, unit tests, etc.) 

## Projects
Calculator contains the math and structure to evulate the formulas.

Calculator Test has the unit tests for the project

CalcInterface is a simple command line interface.

## Notes
It uses a stack and a queue to convert infix equations into postfix notation.
The postfix notation is used to finally evulate the formula.
Available operators are + - * / ^
All operators are binary, numbers can be integers or floats.

The calc class can either take in a single value or operator at a time or a string of several numbers and operators in infix notation.

Upon evulating it will store the result to be used in the next equation. The clear method can be used to reset the current formula or stored value.
