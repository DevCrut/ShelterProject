using ShelterProject.Data;
using ShelterProject.Models;
using ShelterProject.Repositories;
using ShelterProject.Repositories.Generics;

namespace ShelterProject.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        AnimalsRepo IUnitOfWork.AnimalsRepository => throw new NotImplementedException();
        ApplicationUserRepo IUnitOfWork.ApplicationUserRepository => throw new NotImplementedException();
        ShelterRepo IUnitOfWork.ShelterRepository => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            AnimalsRepository = new AnimalsRepo(_context);
            ApplicationUserRepository = new ApplicationUserRepo(_context);
            ShelterRepository = new ShelterRepo(_context);

            AnimalsService = new AnimalsService(this);
            ShelterService = new ShelterService(this);
            ApplicationUserService = new ApplicationUserService(this);
        }
        public AnimalsRepo AnimalsRepository
        {
            get;
            private set;
        }
        public ApplicationUserRepo ApplicationUserRepository
        {
            get;
            private set;
        }
        public ShelterRepo ShelterRepository
        {
            get;
            private set;
        }

        public AnimalsService AnimalsService
        {
            get;
            private set;
        }
        public ShelterService ShelterService
        {
            get;
            private set;
        }
        public ApplicationUserService ApplicationUserService
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