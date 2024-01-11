using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common.Enum
{
    public enum Role
    {
        Customer,
        Staff,
        Admin
    }

    public enum StatusOrder
    {
        WaitToPay,
        Success,
        Failed
    }
}
