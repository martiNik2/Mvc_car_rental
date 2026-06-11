using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure;


public class SqlUserRepository:IUserRepository
{
    private readonly AppDbContext _context;

    public SqlUserRepository(AppDbContext context)
    {
        _context=context;
    }

    public async Task<User?> GetByIdAsync(Guid Id)
    {
        return await _context.Users.FindAsync(Id);
    }
    public async Task<bool> AddUserAsync(User user)
    {
        try{
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> RemoveUserByIdAsync(Guid Id)
    {
        try{
            await _context.Users
            .Where(u=>u.Id==Id)
            .ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}