using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop
{
    public abstract class PlatformAdapter
    {
        public static PlatformAdapter Current { get; set; }
        public abstract IIdentity Identity { get; }
    }
}

