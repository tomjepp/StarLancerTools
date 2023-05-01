using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasJepp.StarLancer.Saves
{
    public class MissionStatus
    {
        public int MissionNumber { get; set; }

        // Typically 0 = total failure, 1 = almost failed, 2 = average, 3 = good, 4 = perfect, 0xffff = not played
        public ushort Outcome { get; set; }
        
        public ushort Kills { get; set; }

        // 0 = none, 1 = ejected once, 2 = ejected twice, 3 = ejected third time, 4 = game crash
        public ushort EjectCount { get; set; }
    }
}
