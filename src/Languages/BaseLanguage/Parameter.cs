using System;
using NomNoml.Interface;

namespace NomNoml.Languages
{
    public abstract class Parameter : ICode
    {
        public string Name { get; protected set; }
        public string Type { get; protected set; }
            
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Parameter c))
                return false;
            
            Parameter p = (Parameter) obj;

            return Type == p.Type &&
                   Name == p.Name;
        }
        protected bool Equals(Parameter other)
        {
            return Type == other.Type && Name == other.Name;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Name);
        }
            
        public abstract string ToCode();
    }
}