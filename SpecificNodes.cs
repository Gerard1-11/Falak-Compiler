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

namespace Falak {

    class Program: Node {}

    class DefinitionList: Node {}

    class FunctionDefinition: Node {}

    class VariableDefinitionList: Node {}

    class ParameterList: Node {}

    class VarList: Node {}

    class VarDef: Node {}

    class StatementList: Node {}

    class StatementAssign: Node {}

    class StatementIncrease: Node {}

    class StatementDecrease: Node {}

    class StatementFuncCall: Node {}

    class StatementIf: Node {}

    class ElseIfList: Node {}

    class Else: Node {}

    class StatementWhile: Node {}

    class StatementDoWhile: Node {}

    class StatementBreak: Node {}

    class StatementReturn: Node {}

    class Empty: Node {}

    class ExpressionList: Node {}

    class Or: Node {}

    class Xor: Node {}

    class And: Node {}

    class EqualTo: Node {}

    class NotEqualTo: Node {}

    class MoreThan: Node {}

    class MoreEqual: Node {}

    class LessThan: Node {}

    class LessEqual: Node {}

    class Mul: Node {}

    class Div: Node {}

    class Mod: Node {}

    class Plus: Node {}

    class Neg: Node {}

    class Not: Node {}

    class FunCall: Node {}

    class VarRef: Node {}

    class True: Node {}

    class False: Node {}

    class Lit_Integer: Node {}

    class Lit_Character: Node {}

    class Lit_String: Node {}

    class LitArray: Node {}

}