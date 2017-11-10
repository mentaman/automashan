using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace ReflectionTry
{
    public class ClassData : Data
    {
        private readonly bool _isFirst;
        private Type _type;

        public ClassData(bool isFirst, Type type)
        {
            Id = isFirst+".class."+type.FullName;
            _isFirst = isFirst;
            _type = type;
        }

        public override string Id { get; protected set; }

        public override string Name
        {
            get
            {
                var attrName = GetNameByAttributes(_type.GetCustomAttributes(true));
                if (attrName != null)
                {
                    return attrName;
                }
                return _type.Name;
            }
        } 

        public override IEnumerable<Data> GetContinue()
        {
            List<FunctionData> list = new List<FunctionData>();

            foreach (MethodInfo method in this._type.GetMethods())
            {
                if (method.DeclaringType == typeof(object))
                    continue;
                
                var functionData = new FunctionData(method);
                list.Add(functionData);
                
                
            }
            
            //TODO: add properties

            return list;
        }

        public override Data ResultType => this;

        public override bool CanContinue => true;
        public override bool CanEnd => false;
        public override string GiveCode(bool isEnd)
        {
            if (_isFirst)
            {
                return "(new "+_type.FullName+"())a=.";
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