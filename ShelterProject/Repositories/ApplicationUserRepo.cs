using Microsoft.EntityFrameworkCore;
using ShelterProject.Data;
using ShelterProject.Models;
using ShelterProject.Repositories.Generics;

namespace ShelterProject.Repositories
{
    public class ApplicationUserRepo : GenericRepo<ApplicationUser>
    {
        public ApplicationUserRepo(ApplicationDbContext context) : base(context) { }

        public async Task<ApplicationUser?> GetById(string id) // Runtime Overwrite because Identity implements IDs as strings
        {
            return await _context.ApplicationUsers.FindAsync(id);
        }

        public async Task<ApplicationUser?> GetUserByEmail(string email)
        {
            return await _context.ApplicationUsers.Where(a => a.NormalizedEmail == email.ToUpper()).FirstOrDefaultAsync();
        }
    }
}
