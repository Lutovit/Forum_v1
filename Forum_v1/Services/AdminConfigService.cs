using Forum_v1.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_v1.Services
{
    public class AdminConfigService:IAdminConfigService
    {
        private  AdminSettings _options;

        public AdminConfigService()
        {
            
        }

        public AdminConfigService(IOptionsSnapshot<AdminSettings> options) 
        {
            _options = options.Value;        
        }



        public string adminName 
        {
            get { return _options.adminName; }
        }

        public string adminEmail
        {
            get { return _options.adminEmail; }
        }

    }
}
