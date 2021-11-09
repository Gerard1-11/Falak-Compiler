/*
  Falak compiler - Data types used in the symbol table.
  Copyright (C) 2013, ITESM CEM

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
using System.Text;
using System.Collections.Generic;

namespace Falak {

    class Type{
    public bool primitive;

    public int arity;
    public HashSet<string> localTable ;
    //public List<object> CustomArray { get; set; }

    public Type(bool primitive, int arity){
        this.primitive = primitive;
        this.arity = arity;
        this.localTable = new HashSet<string>();

    }

    public void setPrimitive(bool primitive){
        this.primitive = primitive;
    }

    public void setArity(int arity){
        this.arity = arity;
    }
    
    public bool getPrimitive(){
        return this.primitive;
    }

    public int getArity(){
        return this.arity;
    }

}
}
