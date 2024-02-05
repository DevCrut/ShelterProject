using Microsoft.EntityFrameworkCore;
using ShelterProject.Data;
using ShelterProject.Models;
using ShelterProject.Repositories.Generics;

namespace ShelterProject.Repositories
{
    public class ShelterRepo : GenericRepo<Shelter>
    {
        public ShelterRepo(ApplicationDbContext context) : base(context) { }


        public async Task<Shelter?> GetShelterFromName(string name)
        {
            return await _context.Shelters.Where(shelter => shelter.Name.ToUpper() == name.ToUpper()).FirstOrDefaultAsync();
        }
        public async Task<List<(string ShelterName, int AnimalCount)>> GetSheltersAnimalsCount() // Runtime Overwrite because Identity implements IDs as strings
        {
            var x = await _context.Shelters
            .Select(shelter => new
            {
                ShelterName = shelter.Name,
                AnimalCount = shelter.Animals.Count()
            })
            .ToListAsync();
            return x.Select(result => (result.ShelterName, result.AnimalCount)).ToList();
        }
        public async Task<List<(string ShelterName, int OwnersCount)>> GetSheltersOwnersCount() // Runtime Overwrite because Identity implements IDs as strings
        {
            var x = await _context.Shelters
            .Select(shelter => new
            {
                ShelterName = shelter.Name,
                AnimalCount = shelter.Owners.Count()
            })
            .ToListAsync();
            return x.Select(result => (result.ShelterName, result.AnimalCount)).ToList();
        }

        public async Task<int> GetShelterOwnersCount(Guid shelterId) // Runtime Overwrite because Identity implements IDs as strings
        {
            var currentShelter = await _context.Shelters.Where(shelter => shelter.Id == shelterId).FirstOrDefaultAsync();

            var allShelters = await this.GetSheltersOwnersCount();
            foreach (var shelter in allShelters)
            {
                if (shelter.ShelterName == currentShelter.Name)
                {
                    return shelter.OwnersCount;
                }
            }

            return 0;
        }

        public async Task<int> GetShelterAnimalsCount(Guid shelterId) // Runtime Overwrite because Identity implements IDs as strings
        {
            var currentShelter = await _context.Shelters.Where(shelter => shelter.Id == shelterId).FirstOrDefaultAsync();

            var allShelters = await this.GetSheltersAnimalsCount();
            foreach (var shelter in allShelters)
            {
                if (shelter.ShelterName.ToUpper() == currentShelter.Name.ToUpper())
                {
                    return shelter.AnimalCount;
                }
            }

            return 0;
        }

    }
}
