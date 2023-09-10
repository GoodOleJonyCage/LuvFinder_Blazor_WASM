
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace LuvFinder_Blazor_WASM.Services
{
    public interface IAuthenticationService
    {
        LuvFinder_ViewModels.User User { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }

    public class AuthenticationService : IAuthenticationService 
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public LuvFinder_ViewModels.User User { get; private set; }

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
            User = await _localStorageService.GetItem<LuvFinder_ViewModels.User>("user");
        }

        public async Task Login(string username, string password)
        {
            //var cars =  await _httpService.Get<Root>("https://vpic.nhtsa.dot.gov/api/vehicles/getallmanufacturers?format=json");
            //var data  = await _httpService.Get<WeatherForecast[]>("/WeatherForecast");
            //var data = await _httpService.Get<WeatherForecast[]>("/User/login");
            //Debug the below line to see why its not working
            User = await _httpService.Post<LuvFinder_ViewModels.User>("/user/login", new { username, password });
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