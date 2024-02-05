using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShelterProject.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Breed {  get; set; }
        public int ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
