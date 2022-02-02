using CashSavvy.Server.Context;
using CashSavvy.Server.Helpers;
using CashSavvy.Server.Interfaces;
using CashSavvy.Shared;

namespace CashSavvy.Server.Services;

public class UserService : IUserService
{
    private readonly CashSavvyDbContext _context;

    public UserService(CashSavvyDbContext context)
    {
        _context = context;
    }
    
    public async Task<LoginResponse?> Login(LoginRequest loginRequest)
    {
        var user = _context.Users.SingleOrDefault(user => user.Username == loginRequest.Username);

        if (user == null)
        {
            return null;
        }

        var passwordHash = HashingHelper.HashUsingPbkdf2(loginRequest.Password, user.PasswordSalt);

        if (user.Password != passwordHash)
        {
            return null;
        }

        var token = await Task.Run(() => TokenHelper.GenerateToken(user));

        return new LoginResponse()
        {
            Username = user.Username,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Token = token
        };

    }
}