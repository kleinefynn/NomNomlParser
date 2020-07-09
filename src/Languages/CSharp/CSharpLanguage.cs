using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NomNoml.Languages
{
    public sealed class CSharpLanguage : Language
    {
        public class CSharpClass : Class
        {
            public CSharpClass(string name, string modifiers, string visibility)
            {
                Name = name;
                Visibility = visibility;
                Modifier = modifiers;
                Properties = new HashSet<Variable>();
                Methods = new HashSet<Method>();
            }
            
            public override string ToCode()
            {
                var methodsAsCode = "";
                var propertiesAsCode = "";
            
                foreach (var v in Properties)
                {
                    propertiesAsCode += "\t" + v.ToCode() + "\n";
                }
                foreach (var m in Methods)
                {
                    methodsAsCode += "\t" + m.ToCode() + "\n";
                }

                //If Modifier is "" don't include it in return
                if (Modifier == "")
                {
                    return $"{Visibility} class {Name}" + "\n" +
                           "{\n" +
                           propertiesAsCode +
                           "\n" +
                           methodsAsCode +
                           "}";
                }

                return $"{Visibility} {Modifier} class {Name}" + "\n" +
                       "{\n" +
                       propertiesAsCode + 
                       "\n" +
                       methodsAsCode + 
                       "}";
            }
        }
        public class CSharpMethod : Method
        {
            public CSharpMethod(string name, string type, string visibility, string modifiers, ISet<Parameter> parameters)
            {
                Name = name;
                Type = type;
                Visibility = visibility;
                Modifier = modifiers;
                Parameters = parameters;
            }
            public override string ToCode()
            {
                var paramsAsCode = "";

                foreach (var param in Parameters)
                {
                    paramsAsCode += param.ToCode();
                    if (!Equals(param, Parameters.Last())) 
                        paramsAsCode += ", ";
                }
                
                if(Modifier == "")
                    return $"{Visibility} {Type} {Name}({paramsAsCode})" + " { }";
                
                return $"{Visibility} {Modifier} {Type} {Name}({paramsAsCode})" + " { }";
            }
        }
        public class CSharpVariable : Variable
        {
            public CSharpVariable(string name, string type, string visibility)
            {
                Name = name;
                Type = type;
                Visibility = visibility;
            }
            public override string ToCode()
            {
                return $"{Visibility} {Type} {Name}";
            }
        }
        public class CSharpParameter : Parameter
        {
            public CSharpParameter(string name, string type)
            {
                Name = name;
                Type = type;
            }
            
            public override string ToCode()
            {
                return $"{Type} {Name}";
            }
        }

        //overrides of Create ... Methods
        public override Class CreateClass(string name, string modifiers, string visibility)
        {
            return new CSharpClass(name, modifiers, visibility);
        }
        public override Method CreateMethod(string name, string type, string visibility, string modifiers, ISet<Parameter> parameters)
        {
            return new CSharpMethod(name, type, visibility, modifiers, parameters);
        }
        public override Variable CreateVariable(string name, string type, string visibility)
        {
            return new CSharpVariable(name, type, visibility);
        }
        public override Parameter CreateParameter(string name, string type)
        {
            return new CSharpParameter(name, type);
        }
    }
}