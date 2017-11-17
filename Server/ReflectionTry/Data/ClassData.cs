using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ReflectionTry
{
    public class ClassData : Data
    {
        private readonly bool _isFirst;
        private Type _type;

        public ClassData(bool isFirst, Type type)
        {
            Id = isFirst + ".class." + type.FullName;
            _isFirst = isFirst;
            _type = type;
        }

        public override string Id { get; protected set; }

        public override string Name
        {
            get
            {
                var attrName = GetNameByAttributes(_type.GetCustomAttributes(true));
                return (attrName != null) ? attrName : _type.Name;
            }
        } 

        public override IEnumerable<Data> GetContinue()
        {
            List<FunctionData> functions = new List<FunctionData>();

            AddMethodsToList(functions, _type.GetMethods(), null);
            AddExtensionMethodsToList(functions, _type.GetInterfaces());
            //TODO: add properties

            return functions;
        }

        private void AddExtensionMethodsToList(List<FunctionData> functions, Type[] interfaces)
        {
            foreach (Type inter in interfaces)
            {
                foreach (MethodInfo method in GetExtensionMethods(inter))
                {
                    if (method.DeclaringType == typeof(object))
                        continue;
                    functions.Add(new FunctionData(method, method.ReturnType == inter ? _type : null));
                }
            }
        }

        private void AddMethodsToList(List<FunctionData> functions, MethodInfo[] methods, Type methodsReturnType)
        {
            foreach (MethodInfo method in methods)
            {
                if (method.DeclaringType == typeof(object))
                    continue;
                functions.Add(new FunctionData(method, methodsReturnType));
            }
        }

        private MethodInfo[] GetExtensionMethods(Type t)
        {
            List<Type> AssTypes = new List<Type>();

            foreach (Assembly item in AppDomain.CurrentDomain.GetAssemblies())
            {
                AssTypes.AddRange(item.GetTypes());
            }

            var query = from type in AssTypes
                        where type.IsSealed && !type.IsGenericType && !type.IsNested
                        from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == t
                        select method;
            return query.ToArray<MethodInfo>();
        }

        public override Data ResultType => this;
        public override bool CanContinue => true;
        public override bool CanEnd => false;
        public override string GiveCode(bool isEnd)
        {
            if (_isFirst)
            {
                return "(new " + _type.FullName + "())a=.";
            }
            else if (isEnd)
            {
                return ";";
            }
            else
            {
                return ".";
            }
        }
    }
}