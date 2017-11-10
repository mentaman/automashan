using System.Collections.Generic;

namespace ReflectionTry
{
    public class IdController
    {
        private static Dictionary<string, Data> ids = new Dictionary<string, Data>();
        private static Dictionary<string, int> smallId = new Dictionary<string, int>();
        private static Dictionary<int, string> smallIdReverse = new Dictionary<int, string>();
        private static int currentIdx = 0;
        public static void SetIdsTo(Data data)
        {
            if (!ids.ContainsKey(data.Id))
            {
                var newIdx = currentIdx++;
                smallId[data.Id] = newIdx;
                smallIdReverse[newIdx] = data.Id;
                ids[data.Id] = data;
                if (data.CanContinue)
                {
                    foreach (var d in data.GetContinue())
                    {
                        SetIdsTo(d);
                    }
                }
            }
        }

        public static IEnumerable<Data> GetAll()
        {
            return ids.Values;
        }

        public static int GetSmallId(string id)
        {
            return smallId[id];
        }
        public static string GetBigId(int id)
        {
            return smallIdReverse[id];
        }
    }
}
