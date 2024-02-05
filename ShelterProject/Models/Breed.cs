using ShelterProject.Models.Generics;

namespace ShelterProject.Models
{
    public class MedicalWriteoffs : BaseEntity
    {
        public int Anthrax {  get; set; }
        public int Brucellosis { get; set; }
        public int Rabies { get; set; }
        public int Influenza { get; set; }
        public int Bluetongue { get; set; }
    }
}
