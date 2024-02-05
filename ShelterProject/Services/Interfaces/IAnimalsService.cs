using ShelterProject.Models;

namespace ShelterProject.Services.Interfaces
{
    public interface IAnimalsService
    {
        public Task Create(Animal entity);
        public Task Delete(Animal entity);
        public Task Update(Animal entity);
    }
}
