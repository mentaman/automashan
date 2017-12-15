using System;
using System.Collections.Generic;

namespace ReflectionTry
{
    public class ParameterData : Data
    {
        public Type Type;

        public override bool CanContinue => true;

        public override bool CanEnd => true;

        public override string Id
        {
            get
            {
                throw new NotImplementedException();
            }

            protected set
            {
                throw new NotImplementedException();
            }
        }

        public override string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Data ResultType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override IEnumerable<Data> GetContinue()
        {
            throw new NotImplementedException();
        }

        public override string GiveCode(bool isEnd)
        {
            throw new NotImplementedException();
        }

        public ParameterData(Type type)
        {
            Id = "Parameter." + type.Name;
        }
    }
}