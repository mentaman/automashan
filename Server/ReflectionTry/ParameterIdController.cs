using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTry
{
    public class ParameterIdController
    {
        private static Dictionary<string, ParameterData> ids = new Dictionary<string, ParameterData>();
        private static Dictionary<string, int> smallId = new Dictionary<string, int>();
        private static Dictionary<int, string> smallIdReverse = new Dictionary<int, string>();
        private static int currentIdx = 0;
        public static void SetIdsTo(ParameterData parameter)
        {
            if (!ids.ContainsKey(parameter.Id))
            {
                var newIdx = currentIdx++;
                smallId[parameter.Id] = newIdx;
                smallIdReverse[newIdx] = parameter.Id;
                ids[parameter.Id] = parameter;
                if (parameter.CanContinue)
                {
                    foreach (var d in parameter.GetContinue())
                    {
                        //SetIdsTo(d);
                    }
                }
            }
        }
    }
}
