using System.Net.NetworkInformation;
using System;
using LuvFinder_Blazor_WASM.Services;
using LuvFinder_ViewModels;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace LuvFinder_Blazor_WASM.Services
{
    //FriendCountService.OnChange += StateHasChanged;
    //StateContainer, above allows any component to subscribe to onchange event for this class, so when
    //its value changes, the target components updates/rerenders
    public class FriendCountService
    {
        private readonly IProfileService _ProfileService;
        public FriendCountService(IProfileService ProfileService)
        {
            _ProfileService = ProfileService;
        }

        public int Count { get; private set; }

        public event Action? OnChange;

        public async void LoadCount(string username)
        {
            Count = await _ProfileService.GetFriendCount(username);
            OnChange?.Invoke();
        }
    }
}
