using System;
using System.Collections.Generic;
using System.Linq;
using NomNoml.Interface;

namespace NomNoml.Languages
{
    public abstract class Class : ICode
    {
        public string Name { get; protected set; }
        public string Modifier { get; protected set; }
        public string Visibility { get; protected set;}
            
        public ISet<Variable> Properties { get; protected set; }
        public ISet<Method> Methods { get; protected set; }
            
        public abstract string ToCode();
            
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Class))
                return false;
            
            var c = (Class) obj;
            
            return Name == c.Name &&
                   Visibility == c.Visibility &&
                   Properties.All(c.Properties.Contains) && 
                   Properties.Count == c.Properties.Count &&
                   Methods.All(c.Methods.Contains) && 
                   Methods.Count == c.Methods.Count;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Visibility, Properties, Methods);
        }
    }
}