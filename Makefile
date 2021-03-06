#
# Falak compiler - Project make file:
# Copyright (C) 2021, ITESM CEM
#
# Luis Daniel Rivera Salinas  - A01374997
# Ricardo David Zambrano Figueroa - A1379700
# Gerardo Arturo Valderrama Quiroz - A01374994
#
# This program is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# This program is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with this program.  If not, see <http://www.gnu.org/licenses/>.
#

falak.exe: Driver.cs Scanner.cs Token.cs TokenCategory.cs Parser.cs SyntaxError.cs Node.cs SpecificNodes.cs SemanticVisitor.cs SemanticError.cs Type.cs WatVisitor.cs

	mcs -debug -out:falak.exe Driver.cs Scanner.cs Token.cs TokenCategory.cs Parser.cs SyntaxError.cs Node.cs SpecificNodes.cs SemanticVisitor.cs SemanticError.cs Type.cs WatVisitor.cs

clean:

	rm -f falak.exe
