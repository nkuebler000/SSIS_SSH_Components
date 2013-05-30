using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSHExecuteCommandTask
{
    public class StringUtil
    {
        public static bool NullOrEmpty(string input)
        {
            if (input == null) { return true; }
            if (input.Trim().Length == 0) { return true; }
            return false;
        }
    }
}
