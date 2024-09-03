using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtharsBot.DataModules
{
    public class Admins
    {
        public int ID { get; set; }
        public ulong UserID { get; set; }
    }
    public class ServerSetting
    {
        public int ID { get; set; }
        public ulong ServerID { get; set; }
        public ulong ChannleID { get; set; }
        public int Time { get; set; } // from hours
        public List<Admins> Admins { get; set; }

    }
}
