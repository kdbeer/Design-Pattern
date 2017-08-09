AbstractExpression  (Expression)
	--declares an interface for executing an operation
TerminalExpression  ( ThousandExpression, HundredExpression, TenExpression, OneExpression )
	--implements an Interpret operation associated with terminal symbols in the grammar.
	--an instance is required for every terminal symbol in the sentence.
NonterminalExpression  ( not used )
	
Context  (Context)
	--contains information that is global to the interpreter
Client  (InterpreterApp)
	--builds (or is given) an abstract syntax tree representing a particular sentence in the language that the grammar defines. The abstract syntax tree is assembled from instances of the NonterminalExpression and TerminalExpression classes
invokes the Interpret operation