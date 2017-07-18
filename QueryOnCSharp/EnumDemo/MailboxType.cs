using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    enum MailboxType : byte
    {
        Unknown = 0,
        UserMailbox = 1,
        RoomMailbox = 2,
        EquipmentMailbox = 4
    }
}
