using CashSavvy.Shared;

namespace CashSavvy.Server.Interfaces;

public interface IUserService
{
    Task<LoginResponse?> Login(LoginRequest loginRequest);
}