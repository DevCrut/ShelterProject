using Microsoft.EntityFrameworkCore;
using ShelterProject.Data;
using ShelterProject.Models;
using ShelterProject.Repositories.Generics;

namespace ShelterProject.Repositories
{
    public class AnimalsRepo : GenericRepo<Animal>
    {
        public AnimalsRepo(ApplicationDbContext context) : base(context) { }

        public async Task<Animal?> GetAnimalByName(string name)
        {
            return await _context.Animals.Where(a => a.Name.ToUpper() == name.ToUpper()).FirstOrDefaultAsync();
        }
        public async Task<Animal?> GetAnimalByBreed(string breed)
        {
            return await _context.Animals.Where(a => a.Breed.ToUpper() == breed.ToUpper()).FirstOrDefaultAsync();
        }

        public async Task<List<Animal>> GetAnimalsByName(string name)
        {
            return await _context.Animals.Where(a => a.Name.ToUpper() == name.ToUpper()).ToListAsync();
        }
        public async Task<List<Animal>> GetAnimalsByBreed(string breed)
        {
            return await _context.Animals.Where(a => a.Breed.ToUpper() == breed.ToUpper()).ToListAsync();
        }


        public async Task<List<(Guid ShelterId, int AnimalsCount)>> GetAnimalsCountByShelters()
        {
            var result = await _context.Animals
                .GroupBy(animal => animal.ShelterId)
                .Select(group => new
                {
                    ShelterId = group.Key,
                    AnimalsCount = group.Count()
                })
                .ToListAsync();

            return result.Select(r => (r.ShelterId, r.AnimalsCount)).ToList();
        }

        public async Task<List<(Guid ShelterId, int AnimalsCount)>> GetAnimalsCountByShelters(int minValue)
        {
            var result = await _context.Animals
                .GroupBy(animal => animal.ShelterId)
                .Select(group => new
                {
                    ShelterId = group.Key,
                    AnimalsCount = group.Count()
                }).Where(group => group.AnimalsCount >= minValue)
                .ToListAsync();

            return result.Select(r => (r.ShelterId, r.AnimalsCount)).ToList();
        }

        public async Task<List<Animal>> GetAnimalsWithMedicalWriteoffs()
        {
            var result = await _context.Animals
            .Include(animal => animal.MedicalWriteoff)
            .ToListAsync();
            return result;
        }
    }
}
