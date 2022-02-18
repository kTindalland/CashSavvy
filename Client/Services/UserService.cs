using CashSavvy.Client.Interfaces;
using CashSavvy.Shared;

namespace CashSavvy.Client.Services;

public class UserService : IUserService
{
    public User CurrentUser { get; } = new();
    
    public Task<bool> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }

    
}