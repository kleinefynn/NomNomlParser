using System.Collections.Generic;
using System.Linq;
using NomNoml.Languages;

namespace NomNoml
{
    public sealed partial class NomNomLVisitor<T>
        where T : Language
    {
        //What to do with a parsed class
        public override object VisitClass(NomnomlParser.ClassContext context)
        {
            var name = context.NAME().GetText();
            
            //Find if there is already a parsed Class with the same name
            var classTmp = Classes
                .SingleOrDefault(umlClass => umlClass.Name == name);

            //if no Class is found create a new one
            if (classTmp == null)
            {
                classTmp = _language.CreateClass(name, "", "public");
                Classes.Add(classTmp);
            }

            //Create List of Variables from Context
            CreateVariables(context.variable(), classTmp.Properties);

            //Create List of Methods from Context
            CreateMethods(context.method(), classTmp.Methods);
            
            return classTmp;
        }

        //ONLY USED BY VisitClass()
        private void CreateMethods(IEnumerable<NomnomlParser.MethodContext> contexts, ISet<Method> methods)
        {
            foreach(var methodContext in contexts)
            {
                methods.Add(CreateMethodFromContext(methodContext));
            }
        }
        private Method CreateMethodFromContext(NomnomlParser.MethodContext context)
        {
            var parameters = new HashSet<Parameter>();

            foreach (var parameter in context.parameter())
            {
                var parameterTmp = _language.CreateParameter(
                    parameter.NAME().GetText(), 
                    parameter.type().GetText()
                    );
                parameters.Add(parameterTmp);
            }

            //Create return type of method (void if none is specified)
            var methodType = context.type() != null ? context.type().GetText() : "void";

            var methodTmp = _language.CreateMethod(
                context.NAME().GetText(), 
                methodType, 
                "public",
                "" , 
                parameters
                );

            return methodTmp;
        }
        private void CreateVariables(NomnomlParser.VariableContext[] contexts, ISet<Variable> properties)
        {
            //Create List of Properties
            foreach (var v in contexts)
            {
                var tmp = _language.CreateVariable(v.NAME().GetText(), v.type().GetText(), "public");
                properties.Add(tmp);
            }
        }
    }
}