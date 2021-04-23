using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Services.Result;

namespace ImageSharing.Services.Interfaces
{
    interface IAuthenticationService
    {
        Task<AuthenticationResult> RegisterUserAsync(string email, string password);
        Task<AuthenticationResult> LoginUserAsync(string email, string password);
        Task<AuthenticationResult> RefreshTokenAsync(Guid refreshToken, string accessToken);
        Task<AuthenticationResult> LogoutUserAsync(Guid refreshToken, Guid accessToken);
    }
}
