using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities.LogTypes
{
    public static class LogTypes
    {
        public static class DeviceLogs
        {
            public const int DeviceLog = 1;
            public const int EventLog = 2;
            public const int TransactionLog = 3;
            public const int SyncLog = 4;
        }




        public static Dictionary<int, string> GetLogTypes(Type LogType)
        {
            Dictionary<int, string> values = new Dictionary<int, string>();
            foreach (var field in LogType.GetFields())
            {
                values.Add(int.Parse(field.GetRawConstantValue().ToString()), field.Name);
            }
            return values;
        }
    }
}
