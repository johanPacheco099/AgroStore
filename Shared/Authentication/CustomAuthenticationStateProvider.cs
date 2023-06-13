using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using AgroStore.Shared;

namespace AgroStore.Authentication.CustomAuthenticationStateProvider
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private User user = new User();

        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<User>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
                if (userSession == null)
                    return await Task.FromResult(new AuthenticationState(_anonymous));

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Email, userSession.email),
                    new Claim(ClaimTypes.Name, userSession.name),
                    new Claim(ClaimTypes.Role, userSession.role),
                    new Claim("UserId", userSession.id.ToString()) 
                }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (System.Exception)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }
        public async Task UpdateAuthenticationState(User userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if (userSession != null)
            {
                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.email),
                    new Claim(ClaimTypes.Role, userSession.role)
                }));
            }
            else
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anonymous;
            }

            var authenticationState = new AuthenticationState(claimsPrincipal);
            base.NotifyAuthenticationStateChanged(Task.FromResult(authenticationState));
        }



        // public async Task UpdateAuthenticationState(User userSession)
        // {
        //     ClaimsPrincipal claimsPrincipal;

        //     if (userSession != null)
        //     {
        //         await _sessionStorage.SetAsync("UserSession", userSession);
        //         claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        //         {
        //             new Claim(ClaimTypes.Name, userSession.email),
        //             new Claim(ClaimTypes.Role, userSession.role)
        //         }));
        //     }
        //     else
        //     {
        //         await _sessionStorage.DeleteAsync("UserSession");
        //         claimsPrincipal = _anonymous;
        //     }

        //     NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        // }
    }
}
