using ShelterProject.Models.Generics;

namespace ShelterProject.Models
{
    public class Ownership : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public Guid ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }
    }
}
