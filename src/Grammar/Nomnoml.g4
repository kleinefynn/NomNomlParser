grammar Nomnoml;

//UML CLASS DIAGRAM SPECIFIC
classifier: '<' NAME '>';
type: NAME;
visibility: PLUS | MINUS;

//DATA TYPES
variable: 
    visibility? NAME ':' type
    ;
method:
	visibility? NAME '(' (parameter ( COMMA parameter)*)? ')' (':' type)?
	;
parameter: 
    NAME ':' type
    ;
class:
	'[' classifier? NAME 
	    (VERTICALBAR variable (SEMICOLON variable)*)? 
	    (VERTICALBAR method (SEMICOLON method)*)? 
	']'
	;
	
//INTERACTION TYPES
association: Association;
dependency: Dependency;
generalization: Generalization;
implementation: Implementation;
composition: Composition;
aggregation: Aggregation;

//RESERVED FOR LATER USE
note: '--';
hidden: '-/-';

//DEFINES HOW CLASSES CAN INTERACT WITH DIFFERENT CLASSES
classInteraction:
	(   class 
		(NAME)? 
		(interaction) 
		(NAME)? 
		class
	)
	| class NAME class
	;
	
interaction
    : association
    | dependency
    | generalization
    | implementation
    | composition
    | aggregation
    | note
    ;
//ROOT RULE
start:
	(class | classInteraction) (class | classInteraction)* EOF;
//--- END PARSER RULES ---

//LEXER RULES
fragment DIGITS: '0' ..'9';
fragment CHARS: 'a'..'z' | 'A'..'Z';

NAME: CHARS+;

//SEPERATORS
VERTICALBAR:    '|';
SEMICOLON:      ';';
COMMA:          ',';

//Interactions:
Association: '-' | '->' | '<->' | '<-';
Dependency: '-->' | '<-->' | '<--';
Generalization: '-:>' | '<:-';
Implementation: '--:>' | '<:--';
Composition: '+-' | '+->' | '<+-';
Aggregation: 'o-' | 'o->' | '<-o';

//SKIP SPECIFIC CHARS
WS: ('\n' | '\r' | '\t' | ' ') -> skip;

//SkIP DIRECTIVES
//DIRECTIVE: '#' .*? '\n' -> skip;

//--- END LEXER RULES ---