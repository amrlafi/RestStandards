grammar Rql;

text  
 : EOF
 | query (BOOLOP_SHORT query)* EOF
 ;

query
 : opr
 | OPAR opr CPAR 
 | 'and' OPAR query COMMA query (COMMA query)* CPAR
 | 'or' OPAR query COMMA query (COMMA query)* CPAR
 ;

opr
 : 'count' OPAR CPAR
 | 'distinct' OPAR CPAR
 | 'first' OPAR CPAR
 | 'eq' OPAR ID COMMA VALUE CPAR
 | 'ge' OPAR ID COMMA VALUE CPAR
 | 'gt' OPAR ID COMMA VALUE CPAR
 | 'le' OPAR ID COMMA VALUE CPAR
 | 'lt' OPAR ID COMMA VALUE CPAR
 | 'ne' OPAR ID COMMA VALUE CPAR
 | 'limit' OPAR INT CPAR
 | 'in' OPAR ID COMMA VALUE_ARRAY CPAR
 | 'select' OPAR ID (COMMA ID)* CPAR
 | 'sort' OPAR SORT_ORDER ID CPAR
 ;

/*
OPERATOR
 : 'count'
 | 'distinct'
 | 'eq'
 | 'first'
 | 'ge'
 | 'gt'
 | 'in'
 | 'le'
 | 'limit'
 | 'ne'
 | 'select'
 | 'sort'
 ;
*/

VALUE
 : STRING
 | INT
 | FLOAT
 ;

SORT_ORDER
 : PLUS
 | MINUS
 ;

VALUE_ARRAY
 : OBRK VALUE* CBRK
 ;

BOOLOP_SHORT 
 : '&' 
 | '|'
 ;

/*
OPR_COUNT : 'count';
OPR_DISTINCT : 'distinct';
OPR_EQ : 'eq';
OPR_FIRST : 'first';
OPR_GE : 'ge';
OPR_GT : 'gt';
OPR_IN : 'in';
OPR_LE : 'le';
OPR_LIMIT : 'limit';
OPR_NE : 'ne';
OPR_SELECT : 'select';
OPR_SORT : 'sort';
*/

OR : '||';
AND : '&&';
EQ : '==';
NEQ : '!=';
GT : '>';
LT : '<';
GTEQ : '>=';
LTEQ : '<=';
PLUS : '+';
MINUS : '-';
ASSIGN : '=';
OBRK : '[';
CBRK : ']';
OPAR : '(';
CPAR : ')';
COMMA : ',';

TRUE : 'true';
FALSE : 'false';

ID
 : [a-zA-Z_] [a-zA-Z_0-9]*
 ;


INT
 : [0-9]+
 ;

FLOAT
 : [0-9]+ '.' [0-9]* 
 | '.' [0-9]+
 ;

SPACE
 : [ \t\r\n] -> skip
 ;

STRING
 : '"' (~["\r\n] | '""')* '"'
 ;

OTHER
 : . 
 ;
