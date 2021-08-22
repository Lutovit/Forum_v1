using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_v1.Services
{
    public  interface IAdminConfigService
    {
        public string adminName { get; }
        public string adminEmail { get; }

    }
}
