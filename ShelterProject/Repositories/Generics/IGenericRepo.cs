using ShelterProject.Models.Generics;

namespace ShelterProject.Repositories.Generics
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
