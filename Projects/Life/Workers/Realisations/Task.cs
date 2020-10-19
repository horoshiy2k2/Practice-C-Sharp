using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Realisations
{
    enum Technologies
    {
        Web,
        SoftwarePC,
        SofwareMobile,
        GameDevPC,
        GameDevMobile
    }

    class Task
    {
        public Technologies Technology { get; set; }
        public int Cost { get; set; }
        //DateTime/TimeSpan DeadLine 

    }
}
