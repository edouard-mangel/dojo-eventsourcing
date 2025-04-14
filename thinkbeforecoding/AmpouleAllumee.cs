using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinkbeforecoding;
public enum AmpouleEvent
{
    None = 0,
    Allumer = 1,
    Eteindre = 2,
    Claquer = 3,
}
public enum AmpouleCommand
{
    SwitchOff = 0,
    SwitchOn = 1,
}