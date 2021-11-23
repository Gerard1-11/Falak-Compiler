# Buttercup runtime library.
# Copyright (C) 2021 Ariel Ortiz, ITESM CEM
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

import sys
from re import compile
from inspect import currentframe
from wasmer import ImportObject, Function, FunctionType, Type

def make_import_object(store):

    INVALID_HANDLE_ERROR = 'Invalid array handle: '
    INVALID_BOUNDS_ERROR = 'Array index out of bounds: '
    HANDLES = []
    VALID_INT_REGEX = compile(r'^\s*-?\d+\s*$')

    def check_bounds(a, i, error_message, fun_name):
            if not (0 <= i < len(a)):
                print(f'Runtime error in function {fun_name}. {error_message}',
                    file=sys.stderr)
                sys.exit(1)    

    #----------------------------------------------------------------
    # Functions to be imported from the Wasm module

    def printi(i: int) -> int:
        print(i, end='')
        return 0
    
    def printc(c: int) -> int:
        print(chr(c), end='')
        return 0

    def prints(s: int) -> int:
        check_bounds(HANDLES, s, INVALID_HANDLE_ERROR + str(s),
            currentframe().f_code.co_name)
        print(''.join([chr(c) for c in HANDLES[s]]), end='')
        return 0

    def println() -> int:
        print()
        return 0

    def readi() -> int:
        data = ''
        while not VALID_INT_REGEX.match(data):
            data = input()
        return int(data)

    def reads() -> int:
        data = input()
        HANDLES.append([ord(c) for c in data])
        return len(HANDLES) - 1
    
    def new(n: int) -> int:
        if n < 0:
            print('Runtime error in function new. '
                f"Can't create a negative size array: {n}",
                file=sys.stderr)
            sys.exit(1)
        HANDLES.append([0] * n)
        return len(HANDLES) - 1

    def size(h: int) -> int:
        check_bounds(HANDLES, h, INVALID_HANDLE_ERROR + str(h),
            currentframe().f_code.co_name)
        return len(HANDLES[h])

    
    def add(h: int, x: int) -> int:
        check_bounds(HANDLES, h, INVALID_HANDLE_ERROR + str(h),
            currentframe().f_code.co_name)
        HANDLES[h].append(x)
        return 0
    
    def get(h: int, i: int) -> int:
        check_bounds(HANDLES, h, INVALID_HANDLE_ERROR + str(h),
            currentframe().f_code.co_name)
        check_bounds(HANDLES[h], i, INVALID_BOUNDS_ERROR + str(i),
            currentframe().f_code.co_name)
        return HANDLES[h][i]

    def set(h: int, i: int, x: int) -> int:
        check_bounds(HANDLES, h, INVALID_HANDLE_ERROR + str(h),
            currentframe().f_code.co_name)
        check_bounds(HANDLES[h], i, INVALID_BOUNDS_ERROR + str(i),
            currentframe().f_code.co_name)
        HANDLES[h][i] = x
        return 0    

    #----------------------------------------------------------------

    import_object = ImportObject()

    import_object.register(
        "falak",
        {
            "printi":  Function(store, printi, FunctionType([Type.I32], [] )),
            "printc":  Function(store, printc, FunctionType([Type.I32], [] )),
            "prints":  Function(store, prints, FunctionType([Type.I32], [] )),
            "println": Function(store, println, FunctionType([], [] )),
            "readi":   Function(store, readi, FunctionType([], [Type.I32] )),
            "reads":   Function(store, reads, FunctionType([], [Type.I32] )),
            "new":     Function(store, new, FunctionType([Type.I32], [Type.I32 ] )),
            "size":    Function(store, size, FunctionType([Type.I32], [Type.I32] )),
            "add":     Function(store, add, FunctionType([Type.I32, Type.I32], [Type.I32] )),
            "get":     Function(store, get, FunctionType([Type.I32, Type.I32], [Type.I32] )),
            "set":     Function(store, set, FunctionType([Type.I32, Type.I32, Type.I32], [] )),
        }
    )

    return import_object
