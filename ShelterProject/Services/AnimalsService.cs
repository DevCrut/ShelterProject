using ShelterProject.Models;
using ShelterProject.Services.Generics;
using ShelterProject.Services.Interfaces;

namespace ShelterProject.Services
{
    public class AnimalsService : BaseEntityService, IAnimalsService
    {
        public AnimalsService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task Create(Animal entity)
        {
            await unitOfWork.AnimalsRepository.Create(entity);
        }
        public async Task Delete(Animal entity)
        {
            await unitOfWork.AnimalsRepository.Delete(entity);
        }
        public async Task Update(Animal entity)
        {
            await unitOfWork.AnimalsRepository.Update(entity);
        }
        public async Task<List<(Guid ShelterId, int AnimalsCount)>> GetAnimalsCountByShelters()
        {
            return await unitOfWork.AnimalsRepository.GetAnimalsCountByShelters();
        }

        public async Task<List<(Guid ShelterId, int AnimalsCount)>> GetAnimalsCountByShelters(int minValue)
        {
            return await unitOfWork.AnimalsRepository.GetAnimalsCountByShelters(minValue);
        }

        public async Task<List<Animal>> GetAnimalsWithMedicalWriteoffs()
        {
            return await unitOfWork.AnimalsRepository.GetAnimalsWithMedicalWriteoffs();
        }
    }
}
