namespace CashSavvy.Client.Interfaces;

public interface ICredentialStorageService
{
    Task<T> GetItemAsync<T>(string key);
    Task SetItemAsync<T>(string key, T value);
    Task RemoveItemAsync(string key);
}