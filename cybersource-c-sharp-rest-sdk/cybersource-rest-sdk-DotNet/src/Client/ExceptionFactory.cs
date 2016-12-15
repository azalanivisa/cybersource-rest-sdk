using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource.Client
{
    public delegate Exception ExceptionFactory(string methodName, HttpWebResponse response);
}
