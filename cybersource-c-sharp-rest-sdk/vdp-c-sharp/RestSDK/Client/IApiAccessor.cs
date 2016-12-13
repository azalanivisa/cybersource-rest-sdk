using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource.Client
{
    public interface IApiAccessor
    {
        string GetTransactionResourcePath();
        string GetTransactionType();
        ExceptionFactory ExceptionFactory { get; set; }
    }
}
