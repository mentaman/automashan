using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ReflectionTry
{
    public class PrimitiveData : Data
    {
        private Type _type;

        public PrimitiveData(Type type)
        {
            Id = "Primitive." + type.FullName;
            _type = type;
        }

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
            throw new NotImplementedException();
        }

        public override Data ResultType => this;

        public override bool CanContinue => false;
        public override bool CanEnd => false;

        public override string Id { get; protected set; }

        public override string GiveCode(bool isEnd)
        {
            throw new NotImplementedException();
        }
    }
}