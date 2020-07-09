using System;
using System.Diagnostics;
using NomNoml.Languages;
using NomNoml.Parser;

namespace NomNoml
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var input =
                UmlFileIO.LoadUmlFromFile("stuff.txt");

            
            var classes = NomNomlLanguageParser.Parse<CSharpLanguage>(input);

            UmlFileIO.WriteToFile("out", classes);
        }
    }
}