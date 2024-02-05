using Microsoft.EntityFrameworkCore;
using ShelterProject.Models;

namespace ShelterProject.Services
{
    public class AnimalsService
    {
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
