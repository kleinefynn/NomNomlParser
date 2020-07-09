using System;
using System.Collections.Generic;
using System.Linq;
using NomNoml.Interface;

namespace NomNoml.Languages
{
    public abstract class Language
    {
        public abstract Class CreateClass(string name, string modifiers, string visibility);
        public abstract Method CreateMethod(string name, string type, string visibility, string modifiers, ISet<Parameter> parameters);
        public abstract Variable CreateVariable(string name, string type, string visibility);
        public abstract Parameter CreateParameter(string name, string type);
    }
}