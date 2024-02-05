using ShelterProject.Data;
using ShelterProject.Models;
using ShelterProject.Repositories;
using ShelterProject.Repositories.Generics;
using ShelterProject.Repositories.UnitOfWork;

namespace MeowSanctuary.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        AnimalsRepo IUnitOfWork.Animals => throw new NotImplementedException();
        ApplicationUserRepo IUnitOfWork.ApplicationUser => throw new NotImplementedException();
        ShelterRepo IUnitOfWork.ShelterRepo => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Animals = new AnimalsRepo(_context);
            ApplicationUser = new ApplicationUserRepo(_context);
            ShelterRepo = new ShelterRepo(_context);
        }
        public AnimalsRepo Animals
        {
            get;
            private set;
        }
        public ApplicationUserRepo ApplicationUser
        {
            get;
            private set;
        }
        public ShelterRepo ShelterRepo
        {
            get;
            private set;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}