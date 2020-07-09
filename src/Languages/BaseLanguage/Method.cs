using System;
using System.Collections.Generic;
using System.Linq;
using NomNoml.Interface;

namespace NomNoml.Languages
{
    public abstract class Method : ICode
    {
        public string Name { get; protected set; }
        public string Type { get; protected set; }
        public string Visibility { get; protected set; }
        public string Modifier { get; protected set; }
        public ISet<Parameter> Parameters { get; protected set; }
        
        
            
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Method c))
                return false;
            
            Method m = (Method) obj;

            return Type == m.Type &&
                   Name == m.Name &&
                   Visibility == m.Visibility &&
                   Parameters.All(m.Parameters.Contains) && 
                   Parameters.Count == m.Parameters.Count;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Type, Parameters, Visibility);
        }
            
        public abstract string ToCode();
    }
}