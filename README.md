# Calculator
Interview test for IssueTrak.

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
