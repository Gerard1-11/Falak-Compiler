/*
  Falak compiler - Program driver.
  Copyright (C) 2021, ITESM CEM

  Luis Daniel Rivera Salinas  - A01374997
  Ricardo David Zambrano Figueroa - A1379700
  Gerardo Arturo Valderrama Quiroz - A01374994
*/

using System;
using System.IO;
using System.Text;

namespace Falak {

    public class Driver {

        const string VERSION = "0.3";

        //-----------------------------------------------------------
        static readonly string[] ReleaseIncludes = {
            "Lexical analysis",
            "Syntatic analysis",
            "AST Construction"
        };

        //-----------------------------------------------------------
        void PrintAppHeader() {
            Console.WriteLine("Falak compiler, version " + VERSION);
            Console.WriteLine(
                "Copyright \u00A9 2013-2021 by L. Rivera, R. Zambrano & G. Valderrama, ITESM CEM.");
            Console.WriteLine("This program is free software; you may "
                + "redistribute it under the terms of");
            Console.WriteLine("the GNU General Public License version 3 or "
                + "later.");
            Console.WriteLine("This program has absolutely no warranty.");
        }

        //-----------------------------------------------------------
        void PrintReleaseIncludes() {
            Console.WriteLine("Included in this release:");
            foreach (var phase in ReleaseIncludes) {
                Console.WriteLine("   * " + phase);
            }
        }

        //-----------------------------------------------------------
        void Run(string[] args) {

            PrintAppHeader();
            Console.WriteLine();
            PrintReleaseIncludes();
            Console.WriteLine();

            if (args.Length != 1) {
                Console.Error.WriteLine(
                    "Please specify the name of the input file.");
                Environment.Exit(1);
            }

            try {
                var inputPath = args[0];
                var input = File.ReadAllText(inputPath);
                var parser = new Parser(
                    new Scanner(input).Scan().GetEnumerator());
                var program = parser.Program();
                Console.WriteLine(program.ToStringTree());

            } catch (Exception e) {

                if (e is FileNotFoundException || e is SyntaxError) {
                    Console.Error.WriteLine(e.Message);
                    Environment.Exit(1);
                }

                throw;
            }
            
        }

        //-----------------------------------------------------------
        public static void Main(string[] args) {
            new Driver().Run(args);
        }
    }
}
