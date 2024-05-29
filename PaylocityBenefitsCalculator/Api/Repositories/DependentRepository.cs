using Api.Contracts.Repositories;
using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class DependentRepository(PaylocityDbContext context) : IDependentRepository
{
    public async Task Add(Dependent dependent)
    {
        await context.AddAsync(dependent);
        await context.SaveChangesAsync();
    }

    public async Task AddRange(ICollection<Dependent> dependents)
    {
        await context.AddRangeAsync(dependents);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Dependent dependent)
    {
        context.Remove(dependent);
        await context.SaveChangesAsync();
    }

    public async Task<List<Dependent>> GetAll() => await context.Dependents.ToListAsync();

    public async Task<Dependent?> GetById(int? id)
    {
        if (id is null) return null;

        return await context.Dependents
                            .FirstOrDefaultAsync(d => d.Id == id.Value);
    }

    public async Task Update(Dependent dependent)
    {
        if (dependent is null) throw new ArgumentNullException(nameof(dependent));

        var existingDependent = await context.Dependents.FirstOrDefaultAsync(d => d.Id == dependent.Id);

        if (existingDependent is null) throw new InvalidOperationException("Dependent not found.");

        existingDependent.FirstName = dependent.FirstName;
        existingDependent.LastName = dependent.LastName;
        existingDependent.DateOfBirth = dependent.DateOfBirth;

        context.Entry(existingDependent).State = EntityState.Modified;

        await context.SaveChangesAsync();
    }
}
