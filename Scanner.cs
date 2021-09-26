/*
  Falak compiler - This class performs the lexical analysis,
  (a.k.a. scanning).
  Falak compiler - Program driver.
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
using System.Text.RegularExpressions;

namespace Falak {

    class Scanner {

        readonly string input;

        static readonly Regex regex = new Regex(
            @"
                (?<MComment> ([<][#](.|\n)*?[#][>]) )
              | (?<SComment>   [#].*       )
              | (?<Newline>    \n          )
              | (?<WhiteSpace> \s          )     # Must go after Newline.
              | (?<Eqto>       [=][=]      )
              | (?<Assign>     [=]         )
              | (?<LessEqual>  [<][=]      )
              | (?<LessThan>   [<]         )
              | (?<MoreEqual>  [>][=]      )
              | (?<MoreThan>   [>]         )
              | (?<Plus>       [+]         )
              | (?<Neg>        [-]         )
              | (?<Mul>        [*]         )
              | (?<Div>        [/]         )
              | (?<Mod>        [%]         )   
              | (?<Or>         [|][|]      )
              | (?<Xor>        [^]         )
              | (?<And>        [&][&]      )
              | (?<NotEqTo>    [!][=]      )
              | (?<Not>        [!]         )
              | (?<Break>      break\b     )
              | (?<Dec>        dec\b       )
              | (?<Do>         do\b        )
              | (?<Elseif>     elseif\b    )
              | (?<Else>       else\b      )
              | (?<False>      false\b     )
              | (?<If>         if\b        )
              | (?<Inc>        inc\b       )
              | (?<Return>     return\b    )
              | (?<True>       true\b      )
              | (?<Var>        var\b       )
              | (?<While>      while\b     )
              | (?<Semicolon>  [;]         )
              | (?<Coma>       [,]         )
              | (?<ParLeft>    [(]         )
              | (?<ParRight>   [)]         )
              | (?<CurlyRight> [}]         )
              | (?<CurlyLeft>  [{]         )
              | (?<SBracketL>  [\[]        )
              | (?<SBracketR>  [\]]        )
              | (?<litChar>   [']([\\](u[\dA-Fa-f]{6}|[nrt\'\\""])|[^\n'\\])['] )
              | (?<litStr>    [""]([\\](u[0-9A-Fa-f]{6}|[nrt\'\\""])|[^\n""\\])*[""] )
              | (?<litInt>    (-)?\d+     )
              | (?<Identifier> [a-zA-Z][a-zA-Z_0-9]* )     # Must go after all keywords
              | (?<Other>      .           )     # Must be last: match any other character.
            ",
            RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
                | RegexOptions.Multiline
            );

        static readonly IDictionary<string, TokenCategory> tokenMap =
            new Dictionary<string, TokenCategory>() {
                {"Eqto", TokenCategory.EQUAL_TO},
                {"Assign", TokenCategory.ASSIGN},
                {"LessEqual", TokenCategory.LESS_EQUAL},
                {"LessThan", TokenCategory.LESS_THAN},
                {"MoreEqual", TokenCategory.MORE_EQUAL},
                {"MoreThan", TokenCategory.MORE_THAN},
                {"Plus", TokenCategory.PLUS},
                {"Neg", TokenCategory.NEG},
                {"Mul", TokenCategory.MUL},
                {"Div", TokenCategory.DIV},
                {"Mod", TokenCategory.MOD},
                {"Or", TokenCategory.OR},
                {"Xor", TokenCategory.XOR},
                {"And", TokenCategory.AND},
                {"NotEqTo", TokenCategory.NOT_EQUAL_TO},
                {"Not", TokenCategory.NOT},
                {"Break", TokenCategory.BREAK},
                {"Dec", TokenCategory.DEC},
                {"Do", TokenCategory.DO},
                {"Elseif", TokenCategory.ELSEIF},
                {"Else", TokenCategory.ELSE},
                {"False", TokenCategory.FALSE},
                {"If", TokenCategory.IF},
                {"Inc", TokenCategory.INC},
                {"Return", TokenCategory.RETURN},
                {"True", TokenCategory.TRUE},
                {"Var", TokenCategory.VAR},
                {"While", TokenCategory.WHILE},
                {"Semicolon", TokenCategory.SEMICOLON},
                {"Coma", TokenCategory.COMA},
                {"ParLeft", TokenCategory.PARENTHESIS_LEFT},
                {"ParRight", TokenCategory.PARENTHESIS_RIGHT},
                {"CurlyLeft", TokenCategory.CURLY_LEFT},
                {"CurlyRight", TokenCategory.CURLY_RIGHT},
                {"SBracketL", TokenCategory.SQUARE_BRACKET_LEFT},
                {"SBracketR", TokenCategory.SQUARE_BRACKET_RIGHT},
                {"litChar", TokenCategory.LIT_CHARACTER},
                {"litStr", TokenCategory.LIT_STRING},
                {"litInt", TokenCategory.LIT_INTEGER},
                {"Identifier", TokenCategory.IDENTIFIER}
            
            };

        public Scanner(string input) {
            this.input = input;
        }

        public IEnumerable<Token> Scan() {

            var result = new LinkedList<Token>();
            var row = 1;
            var columnStart = 0;

            foreach (Match m in regex.Matches(input)) {

                if (m.Groups["Newline"].Success) {

                    row++;
                    columnStart = m.Index + m.Length;

                } else if (m.Groups["WhiteSpace"].Success
                    || m.Groups["SComment"].Success) {

                    // Skip white space and comments.

                }
                else if(m.Groups["MComment"].Success){ 

                     MatchCollection newMatches = Regex.Matches(m.Groups ["MComment"].Value, "\n", RegexOptions.Multiline);

                    if(newMatches.Count > 0){
                        Match lastMatch = newMatches[newMatches.Count - 1];
                        row += newMatches.Count;
                        columnStart = m.Index + lastMatch.Index + lastMatch.Length;
                    }

                }
                 else if (m.Groups["Other"].Success) {

                    // Found an illegal character.
                    result.AddLast(
                        new Token(m.Value,
                            TokenCategory.ILLEGAL_CHAR,
                            row,
                            m.Index - columnStart + 1));

                } else {

                    // Must be any of the other tokens.
                    result.AddLast(FindToken(m, row, columnStart));
                }
            }

            result.AddLast(
                new Token(null,
                    TokenCategory.EOF,
                    row,
                    input.Length - columnStart + 1));

            return result;
        }

        Token FindToken(Match m, int row, int columnStart) {
            foreach (var name in tokenMap.Keys) {
                if (m.Groups[name].Success) {
                    return new Token(m.Value,
                        tokenMap[name],
                        row,
                        m.Index - columnStart + 1);
                }
            }
            throw new InvalidOperationException(
                "regex and tokenMap are inconsistent: " + m.Value);
        }
    }
}
