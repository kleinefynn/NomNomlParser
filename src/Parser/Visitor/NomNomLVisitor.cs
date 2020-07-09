using System;
using System.Linq;
using NomNoml.Languages;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace NomNoml
{
    public sealed partial class NomNomLVisitor<T> : NomnomlBaseVisitor<object>
        where T : Language
    {
        public readonly HashSet<Class> Classes = new HashSet<Class>();
        
        //The language to be parsed as an instance
        private readonly Language _language = GetInstance();

        //METHODS TO CREATE AN INSTANCE OF T
        private static object CreateInstance(Type type)
        {
            var constructor = type.GetConstructor(new Type[0]);

            if (constructor == null && !type.IsValueType)
            {
                throw new NotSupportedException($"Type '{type.FullName}' doesn't have a parameterless constructor");
            }

            var emptyInstance = FormatterServices.GetUninitializedObject(type);

            return constructor?.Invoke(emptyInstance, new object[0]) ?? emptyInstance;
        }
        private static Language GetInstance()
        {
            return (T)CreateInstance(typeof(T));
        }

    }
}