using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSharing.Services.Result
{
    public class AuthenticationResult
    {
        public bool Succes { get; set; }
        public string Error { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
