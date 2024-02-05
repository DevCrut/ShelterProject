using ShelterProject.Models;

namespace ShelterProject.Services.Interfaces
{
    public interface IShelterService
    {
        public Task Create(Shelter entity);
        public Task Delete(Shelter entity);
        public Task Update(Shelter entity);
    }
}
