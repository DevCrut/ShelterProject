namespace ShelterProject.Services.Generics
{
    public class BaseEntityService
    {
        public readonly UnitOfWork unitOfWork;
        public BaseEntityService(UnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }
    }
}
