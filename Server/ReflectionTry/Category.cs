using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTry
{
    [DataContract]
    public class Category : Data
    {
        private readonly string _name;
        private readonly IEnumerable<Data> _continueDatas;

        public Category(IEnumerable<Data> continueDatas, string name)
        {
            Id = name.Base64Encode();
            _continueDatas = continueDatas;
            _name = name;
        }

        public override string Id { get; protected set; }
        public override string Name => _name;
        public override IEnumerable<Data> GetContinue() => _continueDatas;

        public override Data ResultType => new NoData();
        public override bool CanContinue => true;
        public override bool CanEnd => false;
        public override string GiveCode(bool isEnd) => "";
    }
}
