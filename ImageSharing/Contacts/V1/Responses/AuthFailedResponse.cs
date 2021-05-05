using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSharing.Contacts.V1.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
