using ShelterProject.Models;
using ShelterProject.Services.Generics;
using ShelterProject.Services.Interfaces;

namespace ShelterProject.Services
{
    public class ApplicationUserService : BaseEntityService, IApplicationUserService
    {
        public ApplicationUserService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task Update(ApplicationUser entity)
        {
            await unitOfWork.ApplicationUserRepository.Update(entity);
        }
        public async Task Delete(ApplicationUser entity) // GDPR compliance =))
        {
            await unitOfWork.ApplicationUserRepository.Delete(entity);
        }
    }
}
