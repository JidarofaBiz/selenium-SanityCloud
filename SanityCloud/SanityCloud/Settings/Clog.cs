using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityCloud.Settings
{
    class Clog
    {
        public StreamWriter InitalizeLogFile()
        {
            if (Cconf.Instance.browserTest == "chrome")
            {
                if (!File.Exists(Cconf.Instance.pathLog[0]))
                    return new StreamWriter(Cconf.Instance.pathLog[0]);
                else
                    return File.AppendText(Cconf.Instance.pathLog[0]);
            }

            if (Cconf.Instance.browserTest == "firefox")
            {
                if (!File.Exists(Cconf.Instance.pathLog[1]))
                    return new StreamWriter(Cconf.Instance.pathLog[1]);
                else
                    return File.AppendText(Cconf.Instance.pathLog[1]);
            }

            if (Cconf.Instance.browserTest == "ie11")
            {
                if (!File.Exists(Cconf.Instance.pathLog[2]))
                    return new StreamWriter(Cconf.Instance.pathLog[2]);
                else
                    return File.AppendText(Cconf.Instance.pathLog[2]);
            }

            return null;

        }
    }
}
