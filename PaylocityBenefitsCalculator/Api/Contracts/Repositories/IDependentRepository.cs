using Api.Models;

namespace Api.Contracts.Repositories;

public interface IDependentRepository
{
    Task<Dependent?> GetById(int? id);
    Task<List<Dependent>> GetAll();
    Task Add(Dependent dependent);
    Task AddRange(ICollection<Dependent> dependents);
    Task Update(Dependent dependent);
    Task Delete(Dependent dependent);
}
