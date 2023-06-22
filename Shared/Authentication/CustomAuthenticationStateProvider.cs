using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Http;
using AgroStore.Shared;
using AgroStore.Shared.Interfaces;
using AgroStore.Shared.Services;





namespace AgroStore.Authentication.CustomAuthenticationStateProvider
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private User user = new User();
        private int userid;
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
            // _authenticationStateProvider = authenticationStateProvider;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<User>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
                int userId = userSession.id;
                Console.WriteLine(userId);
                if (userSession == null)
                    return await Task.FromResult(new AuthenticationState(_anonymous));

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Email, userSession.email),
                    new Claim(ClaimTypes.Name, userSession.name),
                    new Claim(ClaimTypes.Role, userSession.role)
                }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (System.Exception)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }
        public async Task<int> GetActuallyId()
        {
            var userSessionStorageResult = await _sessionStorage.GetAsync<User>("UserSession");
            var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
            var userId = userSession?.id ?? 0;
            return userId;
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
    }
}
