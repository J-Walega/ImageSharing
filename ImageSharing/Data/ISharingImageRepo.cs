using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Models;

namespace ImageSharing.Data
{
    public interface ISharingImageRepo
    {
        IEnumerable<User> GetAppCommands();
        User GetUserByID(Guid id);
    }
}
