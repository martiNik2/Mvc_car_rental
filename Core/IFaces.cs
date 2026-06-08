namespace Core;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid Id);
    Task<bool> AddUserAsync(User user);
    Task<bool> RemoveUserByIdAsync(Guid Id);
}

public interface IVehicleRepository
{
    Task<Vehicle?> GetByIdAsync(Guid Id);
    Task AddVehicleAsync(Vehicle vehicle);
    Task<IEnumerable<Vehicle>> GetVehiclesAsync(Guid userId);
}

public interface IAuthService
{
    Task<bool> AuthUserAsync(string Username,string Password);
    string GetPasswordHash(string password);
}