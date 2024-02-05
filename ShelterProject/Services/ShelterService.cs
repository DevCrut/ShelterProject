using ShelterProject.Models;
using ShelterProject.Services.Generics;
using ShelterProject.Services.Interfaces;

namespace ShelterProject.Services
{
    public class ShelterService : BaseEntityService, IShelterService
    {
        public ShelterService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task Create(Shelter entity)
        {
            await unitOfWork.ShelterRepository.Create(entity);
        }

        public async Task Delete(Shelter entity)
        {
            await unitOfWork.ShelterRepository.Delete(entity);
        }

        public async Task Update(Shelter entity)
        {
            await unitOfWork.ShelterRepository.Update(entity);
        }
    }
}
