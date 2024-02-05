using ShelterProject.Models;

namespace ShelterProject.Services.Interfaces
{
    public interface IApplicationUserService
    {
        public Task Delete(ApplicationUser entity); // GDPR compliance =))
        public Task Update(ApplicationUser entity);
    }
}
