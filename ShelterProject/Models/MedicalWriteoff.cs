using ShelterProject.Models.Generics;

namespace ShelterProject.Models
{
    public class MedicalWriteoff : BaseEntity
    {
        public bool Anthrax {  get; set; }
        public bool Brucellosis { get; set; }
        public bool Rabies { get; set; }
        public bool Influenza { get; set; }
        public bool Bluetongue { get; set; }

        public Guid AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
