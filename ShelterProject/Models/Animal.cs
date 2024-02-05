using ShelterProject.Models.Generics;

namespace ShelterProject.Models
{
    public class Animal : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Breed {  get; set; }
        public int ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
