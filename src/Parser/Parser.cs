using System.Linq;
using Antlr4.Runtime;
using NomNoml.Languages;

namespace NomNoml.Parser
{
    public static class NomNomlLanguageParser
    {
        public static Class[] Parse<T>(string input)
            where T : Language
        {
            var chars = new AntlrInputStream(input);
            var nomNomlLexer = new NomnomlLexer(chars);
            var tokenStream = new CommonTokenStream(nomNomlLexer);
            var parser = new NomnomlParser(tokenStream);
            
            var visitor = new NomNomLVisitor<T>();
            
            visitor.Visit(parser.start());

            return visitor.Classes.ToArray();
        }
    }
}