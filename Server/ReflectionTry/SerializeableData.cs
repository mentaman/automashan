using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ReflectionTry
{
    [DataContract]
    public class SerializeableData
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public IEnumerable<int> NextIds { get; set; }
    }

    public static class SerializeExtension
    {
        public static SerializeableData GetSerializeable(this Data data)
        {
            return new SerializeableData() { Name = data.Name, Id = IdController.GetSmallId(data.Id), NextIds = data.CanContinue ? data.GetContinue().Select(a => IdController.GetSmallId(a.Id)) : new List<int>()};
        }
        public static IEnumerable<SerializeableData> GetSerializeable(this IEnumerable<Data> data)
        {
            return data.Select(d => d.GetSerializeable());
        }
    }
}
