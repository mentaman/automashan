using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ReflectionTry
{
    public abstract class Data
    {
        public abstract string Id { get; protected set; }
        public abstract string Name { get; }
        public abstract IEnumerable<Data> GetContinue();
        public abstract Data ResultType { get; }
        public abstract bool CanContinue { get; }
        public abstract bool CanEnd { get; }
        public abstract string GiveCode(bool isEnd);

        protected string GetNameByAttributes(Object[] attributes)
        {
            var nameattr = attributes.OfType<TestUIName>().FirstOrDefault();
            if (nameattr == null)
            {
                return null;
            }
            return nameattr.name;
        }
    }
}