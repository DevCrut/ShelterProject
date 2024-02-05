using ShelterProject.Models;
using ShelterProject.Repositories;
using ShelterProject.Repositories.Generics;

namespace ShelterProject.Services
{
    public interface IUnitOfWork : IDisposable

    {
        AnimalsRepo AnimalsRepository { get; }
        ApplicationUserRepo ApplicationUserRepository { get; }
        ShelterRepo ShelterRepository { get; }
        AnimalsService AnimalsService { get; }
        ShelterService ShelterService { get; }
        ApplicationUserService ApplicationUserService { get; }
        int Save();
    }
}
