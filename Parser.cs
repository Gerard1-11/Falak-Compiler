/*
  Falak compiler - This class performs the syntactical analysis,
  (a.k.a. parsing). :D :D
  Copyright (C) 2021, ITESM CEM

  Luis Daniel Rivera Salinas  - A01374997
  Ricardo David Zambrano Figueroa - A1379700
  Gerardo Arturo Valderrama Quiroz - A01374994

  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Falak {

    class Parser {

        static readonly ISet<TokenCategory> firstOfDefinition =
            new HashSet<TokenCategory>() {
                TokenCategory.VAR,
                TokenCategory.IDENTIFIER
            };

        static readonly ISet<TokenCategory> firstOfStatement =
            new HashSet<TokenCategory>() {
                //TokenCategory.ASSIGN,
                TokenCategory.INC,
                TokenCategory.DEC,
                TokenCategory.IDENTIFIER,
                TokenCategory.IF,
                TokenCategory.WHILE,
                TokenCategory.DO,
                TokenCategory.BREAK,
                TokenCategory.RETURN,
                TokenCategory.SEMICOLON
            };
        static readonly ISet<TokenCategory> firstOfBinaryExpr =
            new HashSet<TokenCategory>() {
                TokenCategory.OR,
                //TokenCategory.AND,
                TokenCategory.XOR
            };
        
        static readonly ISet<TokenCategory> firstOfCompare =
            new HashSet<TokenCategory>() {
                TokenCategory.EQUAL_TO,
                TokenCategory.NOT_EQUAL_TO
            };
        
        static readonly ISet<TokenCategory> firstOfRelation =
            new HashSet<TokenCategory>() {
                TokenCategory.LESS_THAN,
                TokenCategory.LESS_EQUAL,
                TokenCategory.MORE_THAN,
                TokenCategory.MORE_EQUAL
            };

        static readonly ISet<TokenCategory> firstOfAddition =
            new HashSet<TokenCategory>() {
                TokenCategory.PLUS,
                TokenCategory.NEG
            };

        static readonly ISet<TokenCategory> firstOfMultiplication =
            new HashSet<TokenCategory>() {
                TokenCategory.MUL,
                TokenCategory.DIV,
                TokenCategory.MOD
            };

        static readonly ISet<TokenCategory> firstOfUnary =
            new HashSet<TokenCategory>() {
                TokenCategory.PLUS,
                TokenCategory.NEG,
                TokenCategory.NOT
            };

        static readonly ISet<TokenCategory> firstOfPrimaryExpr =
            new HashSet<TokenCategory>() {
                TokenCategory.IDENTIFIER,
                TokenCategory.SQUARE_BRACKET_LEFT,
                TokenCategory.TRUE,
                TokenCategory.FALSE,
                TokenCategory.LIT_CHARACTER,
                TokenCategory.LIT_STRING,
                TokenCategory.LIT_INTEGER,
                TokenCategory.PARENTHESIS_LEFT
            };

        static readonly ISet<TokenCategory> firstOfSuperExpression =
            new HashSet<TokenCategory>() {
                TokenCategory.IDENTIFIER,
                TokenCategory.SQUARE_BRACKET_LEFT,
                TokenCategory.TRUE,
                TokenCategory.FALSE,
                TokenCategory.LIT_CHARACTER,
                TokenCategory.LIT_STRING,
                TokenCategory.LIT_INTEGER,
                TokenCategory.PARENTHESIS_LEFT,
                TokenCategory.PLUS,
                TokenCategory.NEG,
                TokenCategory.NOT
            };
      
        IEnumerator<Token> tokenStream;

        public Parser(IEnumerator<Token> tokenStream) {
            this.tokenStream = tokenStream;
            this.tokenStream.MoveNext();
        }

        public TokenCategory CurrentToken {
            get { return tokenStream.Current.Category; }
        }

        public Token Expect(TokenCategory category) {
            if (CurrentToken == category) {
                Token current = tokenStream.Current;
                tokenStream.MoveNext();
                return current;
            } else {
                throw new SyntaxError(category, tokenStream.Current);
            }
        }

        public Node Program(){
           var result = Def_List();
           Expect(TokenCategory.EOF); 
           var newNode = new Program();
           newNode.Add(result);
           return newNode;
       }

       public Node Def_List(){
           var defList = new DefinitionList();
           while (firstOfDefinition.Contains(CurrentToken)){
               var expr1 = Definition();
               defList.Add(expr1);
           }
           return defList;
       } 

       public Node Definition(){
           switch (CurrentToken) {

            case TokenCategory.IDENTIFIER:
                 return Fun_Def();

            case TokenCategory.VAR:
                 return Var_Def();

            default:
                throw new SyntaxError(firstOfDefinition,
                                      tokenStream.Current);
            }
       }

       public Node Fun_Def(){
            var idToken = Expect(TokenCategory.IDENTIFIER);
            Expect(TokenCategory.PARENTHESIS_LEFT);
            var paramList = Param_List();
            Expect(TokenCategory.PARENTHESIS_RIGHT);
            Expect(TokenCategory.CURLY_LEFT);

            // 
            var varDefList = Var_Def_List();
            
            var stmtList = Stmt_List();
            Expect(TokenCategory.CURLY_RIGHT);
            var result = new FunctionDefinition(){ paramList, varDefList, stmtList };
            result.AnchorToken = idToken;
            return result;
       }

       public Node Var_List(){
           var result = Id_List();
           return result;
       }

       public Node Var_Def(){
           Expect(TokenCategory.VAR);
           var result = Var_List();
           Expect(TokenCategory.SEMICOLON);
           return result;
       }

       public Node Var_Def_List(){
           var result = new VariableDefinitionList();
           while(CurrentToken == TokenCategory.VAR){
               var result2 = Var_Def();
               result.Add(result2);
           }
           return result;
       }

       public Node Param_List(){
           var result = new ParameterList();
           if(CurrentToken == TokenCategory.IDENTIFIER){
               var idList = Id_List();
               result.Add(idList);
           }
           return result;
       }

       public Node Id_List(){
            var result = new VarList();
            var newNode = new VarDef();
            newNode.AnchorToken = Expect(TokenCategory.IDENTIFIER);
            result.Add(newNode);
            while(CurrentToken == TokenCategory.COMA){
                newNode = new VarDef();
                Expect(TokenCategory.COMA);
                newNode.AnchorToken = Expect(TokenCategory.IDENTIFIER);
                result.Add(newNode);
            }
            return result;
       }

        public Node Stmt_List(){
            var stmtList = new StatementList();
            while(firstOfStatement.Contains(CurrentToken)){
                stmtList.Add(Stmt());
            }
            return stmtList;
        }

        public Node Stmt(){
            switch(CurrentToken) {
                case TokenCategory.IDENTIFIER:
                    var idToken = Expect(TokenCategory.IDENTIFIER);
                    if(CurrentToken == TokenCategory.PARENTHESIS_LEFT){
                        return Stmt_Fun_Call(idToken);
                    }else{
                        return Stmt_Assign(idToken);
                    }

                case TokenCategory.INC:
                    return Stmt_Incr();

                case TokenCategory.DEC:
                    return Stmt_Decr();

                case TokenCategory.IF:
                    return Stmt_If();

                case TokenCategory.WHILE:
                    return Stmt_While();

                case TokenCategory.DO:
                    return Stmt_Do_While();

                case TokenCategory.BREAK:
                    return Stmt_Break();

                case TokenCategory.RETURN:
                    return Stmt_Return();

                case TokenCategory.SEMICOLON:
                    return Stmt_Empty();

                default:
                throw new SyntaxError(firstOfStatement,
                                      tokenStream.Current);
            }
        }

        public Node Stmt_Assign(Token idToken){
            var result = new StatementAssign();
            result.AnchorToken = idToken;
            Expect(TokenCategory.ASSIGN);
            var expr1 = Expr();
            Expect(TokenCategory.SEMICOLON);
            result.Add(expr1);
            return result;
        }

        public Node Stmt_Incr(){
            var incToken = Expect(TokenCategory.INC);
            Expect(TokenCategory.IDENTIFIER);
            Expect(TokenCategory.SEMICOLON);
            var result = new StatementIncrease();
            result.AnchorToken = incToken;
            return result;
        }

        public Node Stmt_Decr(){
            var decToken = Expect(TokenCategory.DEC);
            Expect(TokenCategory.IDENTIFIER);
            Expect(TokenCategory.SEMICOLON);
            var result = new StatementDecrease();
            result.AnchorToken = decToken;
            return result;
        }

        //Posiblemente le sobre un return --> Eliminar
        public Node Stmt_Fun_Call(Token idToken){
            var result = Fun_Call(idToken);
            return result;
        }

        public Node Fun_Call(Token idToken){
            Expect(TokenCategory.PARENTHESIS_LEFT);
            var exprList = new StatementFuncCall();
            exprList.AnchorToken = idToken;
            if(firstOfSuperExpression.Contains(CurrentToken)){
                exprList.Add(Expr());
                while(CurrentToken == TokenCategory.COMA){
                    Expect(TokenCategory.COMA);
                    exprList.Add(Expr());
                }
            }
            //Expr_List();
            Expect(TokenCategory.PARENTHESIS_RIGHT);
            Expect(TokenCategory.SEMICOLON);
            return exprList;
        }

        public Node Stmt_If(){
            var ifToken = Expect(TokenCategory.IF);
            Expect(TokenCategory.PARENTHESIS_LEFT);
            var expr = Expr();
            Expect(TokenCategory.PARENTHESIS_RIGHT);
            Expect(TokenCategory.CURLY_LEFT);
            var stmtList = Stmt_List();
            Expect(TokenCategory.CURLY_RIGHT);
            var elseIfList = Else_If_List();
            var else1 = Else();
            var result = new StatementIf(){expr, stmtList, elseIfList, else1};
            result.AnchorToken = ifToken;
            return result;
        }

        public Node Else_If_List(){
            var result = new ElseIfList();
            while(CurrentToken == TokenCategory.ELSEIF){
                    var elifToken = Expect(TokenCategory.ELSEIF);
                    Expect(TokenCategory.PARENTHESIS_LEFT);
                    while(firstOfPrimaryExpr.Contains(CurrentToken)){
                        var expr = Expr();
                        result.Add(expr);
                        result.AnchorToken = elifToken;
                    }
                    Expect(TokenCategory.PARENTHESIS_RIGHT);
                    Expect(TokenCategory.CURLY_LEFT);
                    var stmtList = Stmt_List();
                    result.Add(stmtList);
                    Expect(TokenCategory.CURLY_RIGHT);
               }
               return result;
        }

        public Node Else(){
            var result = new Else();
            if(CurrentToken == TokenCategory.ELSE){
                var elseToken = Expect(TokenCategory.ELSE);
                Expect(TokenCategory.CURLY_LEFT);
                var stmtList = Stmt_List();
                result.Add(stmtList);
                result.AnchorToken = elseToken;
                Expect(TokenCategory.CURLY_RIGHT);
            }
            return result;
        }

        public Node Stmt_While(){
            var whileToken = Expect(TokenCategory.WHILE);
            Expect(TokenCategory.PARENTHESIS_LEFT);
            var expr1 = Expr();
            Expect(TokenCategory.PARENTHESIS_RIGHT);
            Expect(TokenCategory.CURLY_LEFT);
            var stmtList = Stmt_List();
            Expect(TokenCategory.CURLY_RIGHT);
            var result = new StatementWhile(){expr1, stmtList};
			result.AnchorToken = whileToken;
			return result;
        }

        public Node Stmt_Do_While(){
            var doToken = Expect(TokenCategory.DO);
            Expect(TokenCategory.CURLY_LEFT);
            var stmtList = Stmt_List();
            Expect(TokenCategory.CURLY_RIGHT);
            Expect(TokenCategory.WHILE);
            Expect(TokenCategory.PARENTHESIS_LEFT);
            var expr1 = Expr();
            Expect(TokenCategory.PARENTHESIS_RIGHT);
            Expect(TokenCategory.SEMICOLON);
            var result = new StatementDoWhile(){stmtList, expr1};
			result.AnchorToken = doToken;
			return result;
        }

        public Node Stmt_Break(){
            var breakToken = Expect(TokenCategory.BREAK);
            Expect(TokenCategory.SEMICOLON);
            var result = new StatementBreak();
            result.AnchorToken = breakToken;
            return result;
        }

        public Node Stmt_Return(){
            var returnToken = Expect(TokenCategory.RETURN);
            var expr1 = Expr();
            Expect(TokenCategory.SEMICOLON);
            var result = new StatementReturn(){expr1};
            result.AnchorToken = returnToken;
            return result;
        }

        public Node Stmt_Empty(){
            var result = new Empty();{
                Expect(TokenCategory.SEMICOLON);
            }
            return result;
        }

        public Node Expr_List(){
            var exprList = new ExpressionList();
            if(firstOfSuperExpression.Contains(CurrentToken)){
                var expr1 = Expr();
                exprList.Add(expr1);
                while(CurrentToken == TokenCategory.COMA){
                    Expect(TokenCategory.COMA);
                    var newExpr = Expr();
                    exprList.Add(newExpr);
                }
            }
            return exprList;
        }

        public Node Expr(){
            var result = Expr_Or();
            return result;
        }

        public Node Expr_Or(){
            var result = Expr_And();
            while(firstOfBinaryExpr.Contains(CurrentToken)){
                switch (CurrentToken) {

                    case TokenCategory.OR:
                        var newOr = new Or();
                        var idToken = Expect(TokenCategory.OR);
                        newOr.Add(result);
                        newOr.Add(Expr_And());
                        newOr.AnchorToken = idToken;
                        result = newOr;
                        break;
                
                    case TokenCategory.XOR:
                        var newXor = new Xor();
                        var idToken2 = Expect(TokenCategory.XOR);
                        newXor.Add(result);
                        newXor.Add(Expr_And());
                        newXor.AnchorToken = idToken2;
                        result = newXor;
                        break;

                    default:
                        throw new SyntaxError(firstOfBinaryExpr,
                                      tokenStream.Current);
                }
            }
            return result;
        }

        //public Node Op_Or(){}

        public Node Expr_And(){
            var result = Expr_Comp();
            while(CurrentToken == TokenCategory.AND){
                    var idToken = Expect(TokenCategory.AND);
                    var newAnd = new And();
                    newAnd.Add(result);
                    newAnd.Add(Expr_Comp());
                    newAnd.AnchorToken = idToken;
                    result = newAnd;
            }
            return result;
        }

        public Node Expr_Comp(){
            var expr1 = Expr_Rel();
            while(firstOfCompare.Contains(CurrentToken)){
                var expr2 = Op_Comp();
                expr2.Add(expr1);
                expr2.Add(Expr_Rel());
                expr1 = expr2;
            }
            return expr1;
        }

        public Node Op_Comp(){
            switch (CurrentToken) {

            case TokenCategory.EQUAL_TO:
                return new EqualTo(){
                    AnchorToken = Expect(TokenCategory.EQUAL_TO)
                };

            case TokenCategory.NOT_EQUAL_TO:
               return new NotEqualTo(){
                   AnchorToken = Expect(TokenCategory.NOT_EQUAL_TO)
               };

            default:
                throw new SyntaxError(firstOfCompare,
                                      tokenStream.Current);
            }
        }

        public Node Expr_Rel(){
            var expr1 = Expr_Add();
            while(firstOfRelation.Contains(CurrentToken)){
                var expr2 = Op_Rel();
                expr2.Add(expr1);
                expr2.Add(Expr_Add());
                expr1 = expr2;
            }
            return expr1;
        }

        public Node Op_Rel(){
            switch (CurrentToken) {

            case TokenCategory.MORE_THAN:
                return new MoreThan(){
                    AnchorToken = Expect(TokenCategory.MORE_THAN)
                };

            case TokenCategory.MORE_EQUAL:
                return new MoreEqual(){
                    AnchorToken = Expect(TokenCategory.MORE_EQUAL)
                };
               
            case TokenCategory.LESS_THAN:
                return new LessThan(){
                    AnchorToken = Expect(TokenCategory.LESS_THAN)
                };

            case TokenCategory.LESS_EQUAL:
               return new LessEqual(){
                    AnchorToken = Expect(TokenCategory.LESS_EQUAL)
                };

            default:
                throw new SyntaxError(firstOfRelation,
                                      tokenStream.Current);
            }
        }

        public Node Expr_Add(){
            var expr1 = Expr_Mul();
            while(firstOfAddition.Contains(CurrentToken)){
                var expr2 = Op_Add();
                expr2.Add(expr1);
                expr2.Add(Expr_Mul());
                expr1 = expr2;
            }
            return expr1;
        }

        public Node Op_Add(){
            switch (CurrentToken) {

            case TokenCategory.PLUS:
                return new Plus(){
                    AnchorToken = Expect(TokenCategory.PLUS)
                };

            case TokenCategory.NEG:
               return new Subs(){
                    AnchorToken = Expect(TokenCategory.NEG)
                };

            default:
                throw new SyntaxError(firstOfAddition,
                                      tokenStream.Current);
            }
        }

        public Node Expr_Mul(){
            var expr1 = Expr_Unary();
            while(firstOfMultiplication.Contains(CurrentToken)){
                var expr2 = Op_Mul();
                expr2.Add(expr1);
                expr2.Add(Expr_Unary());
                expr1 = expr2;
            }
            return expr1;
        }

        public Node Op_Mul(){
            switch (CurrentToken) {

            case TokenCategory.MUL:
               return new Mul(){
                   AnchorToken =  Expect(TokenCategory.MUL)
               };
            
            case TokenCategory.DIV:
                return new Div(){
                    AnchorToken = Expect(TokenCategory.DIV)
                };

            case TokenCategory.MOD:
               return new Mod(){
                   AnchorToken = Expect(TokenCategory.MOD)
               };

            default:
                throw new SyntaxError(firstOfMultiplication,
                                      tokenStream.Current);
            }
        }

        public Node Expr_Unary(){
            if(firstOfUnary.Contains(CurrentToken)){
                var result = Op_Unary();
                result.Add(Expr_Unary());
                return result;
                
            }else if(firstOfSuperExpression.Contains(CurrentToken)){
                var result = Expr_Primary();
                return result;
                
            }else{
                throw new SyntaxError(firstOfUnary,
                                      tokenStream.Current);
            }
        }

        public Node Op_Unary(){
            switch (CurrentToken) {

            case TokenCategory.PLUS:
                return new Positive(){
                    AnchorToken = Expect(TokenCategory.PLUS)
                };

            case TokenCategory.NEG:
               return new Neg(){
                    AnchorToken = Expect(TokenCategory.NEG)
                };

            case TokenCategory.NOT:
               return new Not(){
                    AnchorToken = Expect(TokenCategory.NOT)
                };

            default:
                throw new SyntaxError(firstOfUnary,
                                      tokenStream.Current);
            }
        }

        public Node Expr_Primary(){
            switch (CurrentToken) {

            case TokenCategory.IDENTIFIER:
               var idToken =  Expect(TokenCategory.IDENTIFIER);
                    if(CurrentToken == TokenCategory.PARENTHESIS_LEFT){
                        var result = new FunCall();
                        result.AnchorToken = idToken;
                        Expect(TokenCategory.PARENTHESIS_LEFT);
                        result.Add(Expr_List());
                        Expect(TokenCategory.PARENTHESIS_RIGHT);
                        return result;
                    }else{
                        var result = new VarRef();
                        result.AnchorToken = idToken;
                        return result;
                    }
                

            case TokenCategory.SQUARE_BRACKET_LEFT:
               return Array();

            case TokenCategory.TRUE:
                return new True{
                AnchorToken = Expect(TokenCategory.TRUE)
               };

            case TokenCategory.FALSE:
               return new False{
                AnchorToken = Expect(TokenCategory.FALSE)
               };

            case TokenCategory.LIT_INTEGER:
               return new Lit_Integer{
                AnchorToken = Expect(TokenCategory.LIT_INTEGER)
               };

            case TokenCategory.LIT_CHARACTER:
                return new Lit_Character{
                AnchorToken = Expect(TokenCategory.LIT_CHARACTER)
               };

            case TokenCategory.LIT_STRING:
                return new Lit_String{
                AnchorToken = Expect(TokenCategory.LIT_STRING)
               };

            case TokenCategory.PARENTHESIS_LEFT:
               Expect(TokenCategory.PARENTHESIS_LEFT);
               var result3 = Expr();
               Expect(TokenCategory.PARENTHESIS_RIGHT);
               return result3;

            default:
                throw new SyntaxError(firstOfPrimaryExpr,
                                      tokenStream.Current);
            }
        }

        public Node Array(){
            Expect(TokenCategory.SQUARE_BRACKET_LEFT);
            var result2 = new LitArray();
            result2.Add(Expr_List());
            Expect(TokenCategory.SQUARE_BRACKET_RIGHT);
            return result2;
        }
    
    }
}