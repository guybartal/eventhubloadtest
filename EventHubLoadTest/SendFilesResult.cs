using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHubLoadTest
{
    public class SendFilesResult
    {
        public Dictionary<string, UInt64> Results;
        public int Lines;
    }
}
