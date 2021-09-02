#
# Falak compiler - Program driver.
#  Copyright (C) 2021, ITESM CEM
#
# Luis Daniel Rivera Salinas  - A01374997
# Ricardo David Zambrano Figueroa - A
# Gerardo Arturo Valderrama Quiroz - A01374994
#

falak.exe: Driver.cs Scanner.cs Token.cs TokenCategory.cs

	mcs -out:falak.exe Driver.cs Scanner.cs Token.cs TokenCategory.cs

clean:

	rm -f falak.exe
