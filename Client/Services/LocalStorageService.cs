using System.Text.Json;
using CashSavvy.Client.Interfaces;
using Microsoft.JSInterop;


namespace CashSavvy.Client.Services;

public class LocalStorageService : ICredentialStorageService
{
    private readonly IJSRuntime _jsRuntime;

    public LocalStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    public async Task<T> GetItemAsync<T>(string key)
    {
        var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

        if (json == null)
            return default;

        return JsonSerializer.Deserialize<T>(json);
    }

    public async Task SetItemAsync<T>(string key, T value)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveItemAsync(string key)
    {
        throw new NotImplementedException();
    }
}