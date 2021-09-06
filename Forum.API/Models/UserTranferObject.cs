using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.API.Models
{
    public class UserTranferObject
    {
        public string Id { set; get; }

        public string ClientName { set; get; }

        public string CompanyName { set; get; }

        public string Email { set; get; }

        public string DateOfRegistration { set; get; }

        public bool isBanned { set; get; }

        public bool isDelited { set; get; }
    }
}
