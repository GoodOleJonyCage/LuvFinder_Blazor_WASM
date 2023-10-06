using LuvFinder_Blazor_WASM;
using LuvFinder_Blazor_WASM.Helpers;
using LuvFinder_Blazor_WASM.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
string serverlessBaseURI = builder.Configuration["apiUrl"];
builder.Services
               .AddScoped<IAuthenticationService, AuthenticationService>()
               .AddScoped<IUserService, UserService>()
               .AddScoped<IProfileService, ProfileService>()
               .AddScoped<IChatService, ChatService>()
               .AddScoped<IBlogService, BlogService>()
               .AddScoped<IHttpService, HttpService>()
               .AddScoped<FriendCountService, FriendCountService>() 
               .AddScoped<ILocalStorageService, LocalStorageService>();
 
// configure http client
//builder.Services.AddScoped(x =>
//{
//    var apiUrl = new Uri(builder.Configuration["apiUrl"]);
//    //var apiUrl =  builder.Configuration["apiUrl"] ;
//    //var apiUrl = builder.Configuration.GetValue<string>("apiUrl") ;
//    // use fake backend if "fakeBackend" is "true" in appsettings.json
//    //if (builder.Configuration["fakeBackend"] == "true")
//    //    return new HttpClient(new FakeBackendHandler()) { BaseAddress = apiUrl };
//    //var apiUrl = new ConfigurationBuilder().AddJsonFile("/appsettings.json").Build().GetSection("AppSettings")["apiUrl"];
//    return new HttpClient() { BaseAddress = apiUrl };
//});
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7186/") });


var host = builder.Build();

var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
await authenticationService.Initialize();

await host.RunAsync();
