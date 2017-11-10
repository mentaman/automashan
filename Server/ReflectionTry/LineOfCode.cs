using System.Collections.Generic;
using System.Linq;

namespace ReflectionTry
{
    public class LineOfCode
    {
        private List<Data> datas;

        public LineOfCode(IEnumerable<Data> datas)
        {
            this.datas = datas.ToList();
        }

        public void Add(Data data)
        {
            this.datas.Add(data);
        }

        public string GetLine()
        {
            var str = "";
            for(var i=1; i<this.datas.Count; i++)
            {
                var prev = datas[i-1];
                var current = datas[i];
                str += prev.GiveCode(i != this.datas.Count-1);
            }
            return str;
        }

        public Data GetById(string id)
        {
            return datas.FirstOrDefault(data => data.Id == id);
        }

        public Data ResultType;
    }
}