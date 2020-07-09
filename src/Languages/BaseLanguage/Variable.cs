using System;
using NomNoml.Interface;

namespace NomNoml.Languages
{
    public abstract class Variable : ICode
    {
        public string Name { get; protected set; }
        public string Type { get; protected set; }
        public string Visibility { get; protected set; }
            
            
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Variable c))
                return false;
            
            Variable v = (Variable) obj;

            return Type == v.Type &&
                   Name == v.Name &&
                   Visibility == v.Visibility;
        }
        protected bool Equals(Variable other)
        {
            return Type == other.Type && Name == other.Name && Visibility == other.Visibility;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Name, Visibility);
        }
            
        public abstract string ToCode();
    }
}