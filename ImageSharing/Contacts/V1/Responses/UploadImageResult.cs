using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSharing.Contacts.V1.Responses
{
    public class UploadImageResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
