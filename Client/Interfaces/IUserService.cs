using CashSavvy.Shared;

namespace CashSavvy.Client.Interfaces;

public interface IUserService
{
    Task<bool> LoginAsync(LoginRequest request);
    Task Logout();
    
    User CurrentUser { get; }
}