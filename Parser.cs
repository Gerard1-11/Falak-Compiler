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

        public void Program(){
           Def_List();
           Expect(TokenCategory.EOF); 
       }

       public void Def_List(){
           while (firstOfDefinition.Contains(CurrentToken)){
               Definition();
           }
       } 

       public void Definition(){
           switch (CurrentToken) {

            case TokenCategory.IDENTIFIER:
                 Fun_Def();
                 break;

            case TokenCategory.VAR:
                 Var_Def();
                 break;

            default:
                throw new SyntaxError(firstOfDefinition,
                                      tokenStream.Current);
            }
       }

       public void Fun_Def(){
            Expect(TokenCategory.IDENTIFIER);
            Expect(TokenCategory.PARENTHESIS_LEFT);
            Param_List();
            Expect(TokenCategory.PARENTHESIS_RIGHT);
            Expect(TokenCategory.CURLY_LEFT);
            Var_Def_List();
            Stmt_List();
            Expect(TokenCategory.CURLY_RIGHT);
       }

       public void Var_List(){
           Id_List();
       }

        // Duda
       public void Var_Def(){
           Expect(TokenCategory.VAR);
           Var_List();
           Expect(TokenCategory.SEMICOLON);
       }

       public void Var_Def_List(){
           while(CurrentToken == TokenCategory.VAR){
               Var_Def();
           }
       }

       public void Param_List(){
           if(CurrentToken == TokenCategory.IDENTIFIER){
               Id_List();
           }
       }

       public void Id_List(){
           Expect(TokenCategory.IDENTIFIER);
            while(CurrentToken == TokenCategory.COMA){
                Expect(TokenCategory.COMA);
                Expect(TokenCategory.IDENTIFIER);
            }
       }

        public void Stmt_List(){
            while(firstOfStatement.Contains(CurrentToken)){
                Stmt();
            }
        }

        public void Stmt(){
            switch(CurrentToken) {
                case TokenCategory.IDENTIFIER:
                    Expect(TokenCategory.IDENTIFIER);
                    if(CurrentToken == TokenCategory.PARENTHESIS_LEFT){
                        Stmt_Fun_Call();
                    }else{
                        Stmt_Assign();
                    }
                    break;
                    

                case TokenCategory.INC:
                    Stmt_Incr();
                    break;

                case TokenCategory.DEC:
                    Stmt_Decr();
                    break;

                case TokenCategory.IF:
                    Stmt_If();
                    break;

                case TokenCategory.WHILE:
                    Stmt_While();
                    break;

                case TokenCategory.DO:
                    Stmt_Do_While();
                    break;

                case TokenCategory.BREAK:
                    Stmt_Break();
                    break;

                case TokenCategory.RETURN:
                    Stmt_Return();
                    break;

                case TokenCategory.SEMICOLON:
                    Stmt_Empty();
                    break;

                default:
                throw new SyntaxError(firstOfStatement,
                                      tokenStream.Current);
            }
        }

        public void Stmt_Assign(){
            Expect(TokenCategory.ASSIGN);
            Expr();
            Expect(TokenCategory.SEMICOLON);
        }

        public void Stmt_Incr(){
            Expect(TokenCategory.INC);
            Expect(TokenCategory.IDENTIFIER);
            Expect(TokenCategory.SEMICOLON);
        }

        public void Stmt_Decr(){
            Expect(TokenCategory.DEC);
            Expect(TokenCategory.IDENTIFIER);
            Expect(TokenCategory.SEMICOLON);
        }

        public void Stmt_Fun_Call(){
            Fun_Call();
        }

        public void Fun_Call(){
            Expect(TokenCategory.PARENTHESIS_LEFT);
            Expr_List();
            Expect(TokenCategory.PARENTHESIS_RIGHT);
            Expect(TokenCategory.SEMICOLON);
        }

        public void Stmt_If(){
            Expect(TokenCategory.IF);
            Expect(TokenCategory.PARENTHESIS_LEFT);
            Expr();
            Expect(TokenCategory.PARENTHESIS_RIGHT);
            Expect(TokenCategory.CURLY_LEFT);
            Stmt_List();
            Expect(TokenCategory.CURLY_RIGHT);
            Else_If_List();
            Else();
        }

        public void Else_If_List(){
            while(CurrentToken == TokenCategory.ELSEIF){
                    Expect(TokenCategory.ELSEIF);
                    Expect(TokenCategory.PARENTHESIS_LEFT);
                    Expr();
                    Expect(TokenCategory.PARENTHESIS_RIGHT);
                    Expect(TokenCategory.CURLY_LEFT);
                    Stmt_List();
                    Expect(TokenCategory.CURLY_RIGHT);
               }
        }

        public void Else(){
            if(CurrentToken == TokenCategory.ELSE){
                Expect(TokenCategory.ELSE);
                Expect(TokenCategory.CURLY_LEFT);
                Stmt_List();
                Expect(TokenCategory.CURLY_RIGHT);
            }
        }

        public void Stmt_While(){
            Expect(TokenCategory.WHILE);
            Expect(TokenCategory.PARENTHESIS_LEFT);
            Expr();
            Expect(TokenCategory.PARENTHESIS_RIGHT);
            Expect(TokenCategory.CURLY_LEFT);
            Stmt_List();
            Expect(TokenCategory.CURLY_RIGHT);
        }

        public void Stmt_Do_While(){
            Expect(TokenCategory.DO);
            Expect(TokenCategory.CURLY_LEFT);
            Stmt_List();
            Expect(TokenCategory.CURLY_RIGHT);
            Expect(TokenCategory.WHILE);
            Expect(TokenCategory.PARENTHESIS_LEFT);
            Expr();
            Expect(TokenCategory.PARENTHESIS_RIGHT);
            Expect(TokenCategory.SEMICOLON);
        }

        public void Stmt_Break(){
            Expect(TokenCategory.BREAK);
            Expect(TokenCategory.SEMICOLON);
        }

        public void Stmt_Return(){
            Expect(TokenCategory.RETURN);
            Expr();
            Expect(TokenCategory.SEMICOLON);
        }

        public void Stmt_Empty(){
            Expect(TokenCategory.SEMICOLON);
        }

        public void Expr_List(){
            if(firstOfSuperExpression.Contains(CurrentToken)){
                Expr();
                while(CurrentToken == TokenCategory.COMA){
                    Expect(TokenCategory.COMA);
                    Expr();
                }
            }
        }

        public void Expr(){
            Expr_Or();
        }

        public void Expr_Or(){
            Expr_And();
            while(firstOfBinaryExpr.Contains(CurrentToken)){
                Op_Or();
                Expr_And();
            }
        }

        public void Op_Or(){
            switch (CurrentToken) {

            case TokenCategory.OR:
                Expect(TokenCategory.OR);
                break;

            case TokenCategory.XOR:
               Expect(TokenCategory.XOR);
               break;

            default:
                throw new SyntaxError(firstOfBinaryExpr,
                                      tokenStream.Current);
            }
        }

        public void Expr_And(){
            Expr_Comp();
            while(CurrentToken == TokenCategory.AND){
                    Expect(TokenCategory.AND);
                    Expr_Comp();
            }
        }

        public void Expr_Comp(){
            Expr_Rel();
            while(firstOfCompare.Contains(CurrentToken)){
                Op_Comp();
                Expr_Rel();
            }
        }

        public void Op_Comp(){
            switch (CurrentToken) {

            case TokenCategory.EQUAL_TO:
                Expect(TokenCategory.EQUAL_TO);
                break;

            case TokenCategory.NOT_EQUAL_TO:
               Expect(TokenCategory.NOT_EQUAL_TO);
               break;

            default:
                throw new SyntaxError(firstOfCompare,
                                      tokenStream.Current);
            }
        }

        public void Expr_Rel(){
            Expr_Add();
            while(firstOfRelation.Contains(CurrentToken)){
                Op_Rel();
                Expr_Add();
            }
        }

        public void Op_Rel(){
            switch (CurrentToken) {

            case TokenCategory.MORE_THAN:
                Expect(TokenCategory.MORE_THAN);
                break;

            case TokenCategory.MORE_EQUAL:
               Expect(TokenCategory.MORE_EQUAL);
               break;
            
            case TokenCategory.LESS_THAN:
                Expect(TokenCategory.LESS_THAN);
                break;

            case TokenCategory.LESS_EQUAL:
               Expect(TokenCategory.LESS_EQUAL);
               break;

            default:
                throw new SyntaxError(firstOfRelation,
                                      tokenStream.Current);
            }
        }

        public void Expr_Add(){
            Expr_Mul();
            while(firstOfAddition.Contains(CurrentToken)){
                Op_Add();
                Expr_Mul();
            }
        }

        public void Op_Add(){
            switch (CurrentToken) {

            case TokenCategory.PLUS:
                Expect(TokenCategory.PLUS);
                break;

            case TokenCategory.NEG:
               Expect(TokenCategory.NEG);
               break;

            default:
                throw new SyntaxError(firstOfAddition,
                                      tokenStream.Current);
            }
        }

        public void Expr_Mul(){
            Expr_Unary();
            while(firstOfMultiplication.Contains(CurrentToken)){
                Op_Mul();
                Expr_Unary();
            }
        }

        public void Op_Mul(){
            switch (CurrentToken) {

            case TokenCategory.MUL:
                Expect(TokenCategory.MUL);
                break;
            
            case TokenCategory.DIV:
                Expect(TokenCategory.DIV);
                break;

            case TokenCategory.MOD:
               Expect(TokenCategory.MOD);
               break;

            default:
                throw new SyntaxError(firstOfMultiplication,
                                      tokenStream.Current);
            }
        }

        public void Expr_Unary(){
            if(firstOfUnary.Contains(CurrentToken)){
                Op_Unary();
                Expr_Unary();
                
            }else if(firstOfSuperExpression.Contains(CurrentToken)){
                Expr_Primary();
                
            }else{
                throw new SyntaxError(firstOfUnary,
                                      tokenStream.Current);
            }
        }

        public void Op_Unary(){
            switch (CurrentToken) {

            case TokenCategory.PLUS:
                Expect(TokenCategory.PLUS);
                break;

            case TokenCategory.NEG:
               Expect(TokenCategory.NEG);
               break;

            case TokenCategory.NOT:
               Expect(TokenCategory.NOT);
               break;

            default:
                throw new SyntaxError(firstOfUnary,
                                      tokenStream.Current);
            }
        }

        public void Expr_Primary(){
            switch (CurrentToken) {

            case TokenCategory.IDENTIFIER:
                Expect(TokenCategory.IDENTIFIER);
                    if(CurrentToken == TokenCategory.PARENTHESIS_LEFT){
                        Expect(TokenCategory.PARENTHESIS_LEFT);
                        Expr_List();
                        Expect(TokenCategory.PARENTHESIS_RIGHT);
                    }
                break;

            case TokenCategory.SQUARE_BRACKET_LEFT:
               Array();
               break;

            case TokenCategory.TRUE:
               Expect(TokenCategory.TRUE);
               break;

            case TokenCategory.FALSE:
               Expect(TokenCategory.FALSE);
               break;

            case TokenCategory.LIT_INTEGER:
               Expect(TokenCategory.LIT_INTEGER);
               break;

            case TokenCategory.LIT_CHARACTER:
               Expect(TokenCategory.LIT_CHARACTER);
               break;

            case TokenCategory.LIT_STRING:
               Expect(TokenCategory.LIT_STRING);
               break;

            case TokenCategory.PARENTHESIS_LEFT:
               Expect(TokenCategory.PARENTHESIS_LEFT);
               Expr();
               Expect(TokenCategory.PARENTHESIS_RIGHT);
               break;

            default:
                throw new SyntaxError(firstOfPrimaryExpr,
                                      tokenStream.Current);
            }
        }

        public void Array(){
            Expect(TokenCategory.SQUARE_BRACKET_LEFT);
            Expr_List();
            Expect(TokenCategory.SQUARE_BRACKET_RIGHT);
        }
    
    }
}