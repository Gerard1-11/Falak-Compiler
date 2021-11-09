/*
  Falak compiler - Semantic analyzer.
  Copyright (C) 2013-2021 , ITESM CEM
  
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
using System.Linq;

namespace Falak {

    class SemanticVisitor {

       public HashSet<string> GlobalVariableTable;
       public IDictionary<string, Type> GlobalFunctionTable;

       public int cycles, pass;
       public string FunName;

       public bool definitionBody;

       void DeclareAPI()
        {
            GlobalFunctionTable["printi"].setArity(1);
            GlobalFunctionTable["printc"].setArity(1);
            GlobalFunctionTable["prints"].setArity(1);
            GlobalFunctionTable["println"].setArity(0);
            GlobalFunctionTable["readi"].setArity(0);
            GlobalFunctionTable["reads"].setArity(0);
            GlobalFunctionTable["new"].setArity(1);
            GlobalFunctionTable["size"].setArity(1);
            GlobalFunctionTable["add"].setArity(2);
            GlobalFunctionTable["get"].setArity(2);
            GlobalFunctionTable["set"].setArity(3);

            GlobalFunctionTable["printi"].setPrimitive(true);
            GlobalFunctionTable["printc"].setPrimitive(true);
            GlobalFunctionTable["prints"].setPrimitive(true);
            GlobalFunctionTable["println"].setPrimitive(true);
            GlobalFunctionTable["readi"].setPrimitive(true);
            GlobalFunctionTable["reads"].setPrimitive(true);
            GlobalFunctionTable["new"].setPrimitive(true);
            GlobalFunctionTable["size"].setPrimitive(true);
            GlobalFunctionTable["add"].setPrimitive(true);
            GlobalFunctionTable["get"].setPrimitive(true);
            GlobalFunctionTable["set"].setPrimitive(true);
        }

       //-----------------------------------------------------------
        public SemanticVisitor() {
           pass = 1;
           cycles = 0;
           definitionBody = false;

           GlobalVariableTable = new HashSet<string>();
           GlobalFunctionTable = new SortedDictionary<string, Type>();

           DeclareAPI();
        }

        //-----------------------------------------------------------
        public void Visit(Program node) {
            VisitChildren(node);
            if(!GlobalFunctionTable.ContainsKey("main")){
                throw new SemanticError("There is no main function");
            }
            var tableRow = GlobalFunctionTable["main"];
            if(tableRow.getArity() > 0){
                throw new SemanticError("Main function can not have any parameters");
            }
            VisitChildren(node);
        }

        //-----------------------------------------------------------
        public void Visit(DefinitionList node) {
            definitionBody = true;
            VisitChildren(node);
            definitionBody = false;
        }


        //-----------------------------------------------------------
        public void Visit(VarDef node) {
            var variableName = node.AnchorToken.Lexeme;
            if(pass == 1){
                if(GlobalVariableTable.Contains(variableName)){
                    throw new SemanticError("Variable" + variableName +  " is already declared.", node.AnchorToken);
                }else{
                    GlobalVariableTable.Add(variableName);
                }
            }
            else{
                var tableRow = GlobalFunctionTable[FunName];
                if(!GlobalVariableTable.Contains(variableName)){
                    if(tableRow.localTable.Contains(variableName)){
                        throw new SemanticError("Variable" + variableName +  " is already declared inside" + FunName, node.AnchorToken);
                    }else{
                        tableRow.localTable.Add(variableName);
                    }
                    
                }else{
                    if(definitionBody){
                        tableRow.localTable.Add(variableName);
                    }
                }
            }

        }

        //-----------------------------------------------------------
        public void Visit(VarList node) {
            VisitChildren(node);   
        }

        //-----------------------------------------------------------
        public void Visit(FunctionDefinition node) {
            FunName = node.AnchorToken.Lexeme;
            if(pass == 1){
                if(GlobalFunctionTable.ContainsKey(FunName)){
                    throw new SemanticError(FunName + "function already exists", node.AnchorToken);
                }
                else{
                    if(node[0] is ExpressionList){
                        int arity = 0;
                        foreach (var id in node[0]){
                            arity++;
                        }
                        GlobalFunctionTable[FunName].setArity(arity);
                        GlobalFunctionTable[FunName].setPrimitive(false);
                    }
                    else{
                        GlobalFunctionTable[FunName].setArity(0);
                        GlobalFunctionTable[FunName].setPrimitive(false);
                    }

                }   
            }else{
                 VisitChildren(node);
            }
        }

        //-----------------------------------------------------------
        public void Visit(VariableDefinitionList node) {
            VisitChildren(node);
        }

         //-----------------------------------------------------------
        public void Visit(ParameterList node) {
            VisitChildren(node);
        }

        //-----------------------------------------------------------
        public void Visit(StatementList node) {
            VisitChildren(node);
        }

        //-----------------------------------------------------------
        public void Visit(StatementAssign node) {
            var variableName = node.AnchorToken.Lexeme;
            var tableRow = GlobalFunctionTable[FunName];
            
            if(tableRow.localTable.Contains(variableName)){
                VisitChildren(node);
            }
            else if(GlobalVariableTable.Contains(variableName)){
                VisitChildren(node);
            }
            else{
                throw new SemanticError("Undeclared variable: " + variableName);

            }
        }

         //-----------------------------------------------------------
        public void Visit(StatementIncrease node) {
            //solo consume
        }

        //-----------------------------------------------------------
        public void Visit(StatementDecrease node) {
            //solo consume
        }

        //-----------------------------------------------------------
        public void Visit(StatementIf node) {
            // Visit((dynamic) node[0]); //Expr
            // Visit((dynamic) node[1]); //StmtList :C
            // Visit((dynamic) node[2]); //ElseIfList
            // Visit((dynamic) node[3]); //Else
            VisitChildren(node);
        }

        //-----------------------------------------------------------
        public void Visit(ElseIfList node) {
            VisitChildren(node);
        }

        //-----------------------------------------------------------
        public void Visit(Else node) { 
            VisitChildren(node);
        }

        //-----------------------------------------------------------
        public void Visit(StatementWhile node) {
            cycles++;
            // Visit((dynamic) node[0]); //Expr
            // Visit((dynamic) node[1]); //StmtList :C
            VisitChildren(node);
            cycles--;
        }

        //-----------------------------------------------------------
        public void Visit(StatementDoWhile node) {
            cycles++;
            // Visit((dynamic) node[0]); //Expr
            // Visit((dynamic) node[1]); //StmtList :C
            VisitChildren(node);
            cycles--;
        }

        //-----------------------------------------------------------
        public void Visit(StatementBreak node) {
            if(cycles <= 0){
                throw new SemanticError("Break statement was used outside loop cycle" + node.AnchorToken);
            }
        }

        //-----------------------------------------------------------
        public void Visit(StatementReturn node) {
           VisitChildren(node);
        }

        //-----------------------------------------------------------
        public void Visit(Empty node) {
            //Solo se consume
        }

        //-----------------------------------------------------------
        public void Visit(ExpressionList node) {
            VisitChildren(node);
        }

         //-----------------------------------------------------------
        public void Visit(Or node) {
            VisitChildren(node);
        }

         //-----------------------------------------------------------
        public void Visit(Xor node) {
            VisitChildren(node);
        }

         //-----------------------------------------------------------
        public void Visit(And node) {
            VisitChildren(node);
        }

        //-----------------------------------------------------------
        public void Visit(EqualTo node) {
            VisitChildren(node);

        }

        //-----------------------------------------------------------
        public void Visit(NotEqualTo node) {
            VisitChildren(node);

        }

        //-----------------------------------------------------------
        public void Visit(LessThan node) {
            VisitChildren(node);

        }

        //-----------------------------------------------------------
        public void Visit(LessEqual node) {
            VisitChildren(node);

        }

        //-----------------------------------------------------------
        public void Visit(MoreThan node) {
            VisitChildren(node);

        }

        //-----------------------------------------------------------
        public void Visit(MoreEqual node) {
            VisitChildren(node);

        }

        //-----------------------------------------------------------
        public void Visit(Plus node) {
            VisitChildren(node);

        }

        //-----------------------------------------------------------
        public void Visit(Subs node) {
            VisitChildren(node);

        }

        //-----------------------------------------------------------
        public void Visit(Mul node) {
            VisitChildren(node);

        }

        //-----------------------------------------------------------
        public void Visit(Div node) {
            VisitChildren(node);

        }

        //-----------------------------------------------------------
        public void Visit(Mod node) {
            VisitChildren(node);

        }

         //-----------------------------------------------------------
        public void Visit(Positive node) {
            VisitChildren(node);
        }

         //-----------------------------------------------------------
        public void Visit(Neg node) {
            VisitChildren(node);
        }

         //-----------------------------------------------------------
        public void Visit(Not node) {
            VisitChildren(node);
        }

        //-----------------------------------------------------------
        public void Visit(FunCall node) {
            var functionName = node.AnchorToken.Lexeme;
            if(!GlobalFunctionTable.ContainsKey(functionName)){
                throw new SemanticError(functionName + " was not declared.");
            }
            if(node[0].getCount()!= GlobalFunctionTable[functionName].getArity()){
                throw new SemanticError(functionName + " takes a different number of arguments.", node.AnchorToken);

            }
            VisitChildren(node);
        }

        //-----------------------------------------------------------
        public void Visit(VarRef node) {
            var varName = node.AnchorToken.Lexeme;
            var tableRow = GlobalFunctionTable[FunName];
            if(!(GlobalVariableTable.Contains(varName)) && !(tableRow.localTable.Contains(varName)) ){
                throw new SemanticError(varName + " was not declared.", node.AnchorToken);    
            }
        }


        //-----------------------------------------------------------
        public void Visit(True node) {
            var lexeme = node.AnchorToken.Lexeme;
            try {
                // Solo lo consume

            }catch (OverflowException) {
                throw new SemanticError("Boolean literal too large: " + lexeme, node.AnchorToken);
            }

        }

        //-----------------------------------------------------------
        public void Visit(False node) {
            var lexeme = node.AnchorToken.Lexeme;
            try {
                //Solo lo consume

            }catch (OverflowException) {
                throw new SemanticError("Boolean literal too large: " + lexeme, node.AnchorToken);
            }
        }

        //-----------------------------------------------------------
        public void Visit(Lit_Integer node) {
            var lexeme = node.AnchorToken.Lexeme;
            try {
                //Solo lo consume
                //Convert.ToInt32(lexeme);

            }catch (OverflowException) {
                throw new SemanticError("Integer literal too large: " + lexeme, node.AnchorToken);
            }
        }

        //-----------------------------------------------------------
        public void Visit(Lit_Character node) {
            var lexeme = node.AnchorToken.Lexeme;
            try {
                //Solo lo consume

            }catch (OverflowException) {
                throw new SemanticError("Char literal too large: " + lexeme, node.AnchorToken);
            }

        }

         //-----------------------------------------------------------
        public void Visit(Lit_String node) {
            var lexeme = node.AnchorToken.Lexeme;
            try {
                //Solo lo consume

            }catch (OverflowException) {
                throw new SemanticError("String literal too large: " + lexeme, node.AnchorToken);
            }

        }


         //-----------------------------------------------------------
        public void Visit(LitArray node) {
            //VisitChildren(node);
        }
        


        //-----------------------------------------------------------
        void VisitChildren(Node node) {
            foreach (var n in node) {
                Visit((dynamic) n);
            }
        }
        
    }
}
