using LuvFinder_Blazor_WASM.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace LuvFinder_Blazor_WASM.Services
{
    public interface IAuthenticationService
    {
        User User { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }

    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public User User { get; private set; }

        public AuthenticationService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        ) {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<User>("user");
        }

        public async Task Login(string username, string password)
        {
            //User = await _httpService.Post<User>("/users/authenticate", new { username, password });
            User = new User() { Id = 8, FirstName = "Maqsood", LastName = "Khan", Token = "12345", Username = "himan_sa@yahoo.com" };
            await _localStorageService.SetItem("user", User);
        }


        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem("user");
            _navigationManager.NavigateTo("login");
        }
    }
}