using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ReflectionTry
{
    public class NoData : Data
    {
        public NoData()
        {
            Id = "No.Data";
        }
        public override string Id { get; protected set; }
        public override string Name => "Nothing";
        public override IEnumerable<Data> GetContinue()
        {
            throw new NotImplementedException();
        }

        public override Data ResultType => this;
        public override bool CanContinue => false;
        public override bool CanEnd => false;
        public override string GiveCode(bool isEnd)
        {
            throw new NotImplementedException();
        }
    }
}