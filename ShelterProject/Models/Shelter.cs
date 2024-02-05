using ShelterProject.Models.Generics;

namespace ShelterProject.Models
{
    public class Shelter : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<Ownership> Owners { get; set; }
    }
}
