using ShelterProject.Models.Generics;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShelterProject.Models
{
    public class Animal : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Breed {  get; set; }
        public DateTime BirthDate { get; set; }

        public Guid ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }

        public Guid MedicalWriteoffId { get; set; }
        public virtual MedicalWriteoff MedicalWriteoff { get; set; }
    }
}
