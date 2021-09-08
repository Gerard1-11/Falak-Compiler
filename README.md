# Falak compiler, version 0.1

This program is free software. You may redistribute it under the terms of the GNU General Public License version 3 or later. See `license.txt` for details.

Included in this release:

* Lexical analysis

## How to Build

At the terminal type:

    make

## How to Run

At the terminal type:

    mono falak.exe <falak_source_file>

Where `<falak_source_file>` is the name of a Buttercup source file. You can try with these files:

* `001_hello.falak`
* `002_binary.falak`
* `003_palindrome.falak`
* `005_arrays.falak`

## How to Clean

To delete all the files that get created automatically, at the terminal type:

    make clean
