using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class SqlVehicleRepository : IVehicleRepository
{
    private readonly AppDbContext _context;

    public SqlVehicleRepository(AppDbContext context)
    {
        _context=context;
    }

    public async Task<Vehicle?> GetByIdAsync(Guid Id)
    {
        return await _context.Vehicles.FindAsync(Id);
    }
    public async Task AddVehicleAsync(Vehicle vehicle)
    {
        await _context.Vehicles.AddAsync(vehicle);
    }
    public async Task<IEnumerable<Vehicle>> GetVehiclesAsync(Guid userId)
    {
        return await _context.Vehicles
        .Where(v=>v.UserId==userId)
        .ToListAsync();
    }
}