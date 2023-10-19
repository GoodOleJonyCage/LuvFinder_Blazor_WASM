using LuvFinder_Blazor_WASM;
using LuvFinder_Blazor_WASM.Helpers;
using LuvFinder_Blazor_WASM.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
string serverlessBaseURI = builder.Configuration["apiUrl"];

builder.Services.AddMudServices();

builder.Services
               .AddScoped<IAuthenticationService, AuthenticationService>()
               .AddScoped<IUserService, UserService>()
               .AddScoped<IProfileService, ProfileService>()
               .AddScoped<IChatService, ChatService>()
               .AddScoped<IBlogService, BlogService>()
               .AddScoped<ISearchService, SearchService>()
               .AddScoped<IHttpService, HttpService>()
               .AddScoped<FriendCountStateContainer, FriendCountStateContainer>()
               .AddScoped<BlogCountStateContainer, BlogCountStateContainer>()
               .AddScoped<FriendProfileStateContainer, FriendProfileStateContainer>()
               .AddScoped<ChatCountStateContainer, ChatCountStateContainer>()
               .AddScoped<RegisterUserStateContainer, RegisterUserStateContainer>()
               .AddScoped<ISearchStateContainer, SearchStateContainer>()
               .AddScoped<ILocalStorageService, LocalStorageService>();

// configure http client
builder.Services.AddScoped(x =>
{
    var apiUrl = new Uri(builder.Configuration["apiUrl"].ToString());
    return new HttpClient() { BaseAddress = apiUrl };
});



var host = builder.Build();

var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
await authenticationService.Initialize();

await host.RunAsync();
