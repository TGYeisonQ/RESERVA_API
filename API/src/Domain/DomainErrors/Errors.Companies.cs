using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainErrors;

public static partial class Errors
{
    public static class Company
    {
        public static Error AddressWithBadFormat =>
            Error.Validation("Company.Address", "Address is not valid");
    }
}
