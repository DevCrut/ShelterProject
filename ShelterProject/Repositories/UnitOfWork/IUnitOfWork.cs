using ShelterProject.Models;
using ShelterProject.Repositories.Generics;

namespace ShelterProject.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable

    {
        AnimalsRepo Animals { get; }
        ApplicationUserRepo ApplicationUser { get; }
        ShelterRepo ShelterRepo { get; }
        int Save();
    }
}
