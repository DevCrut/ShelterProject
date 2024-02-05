namespace ShelterProject.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }

    }
}
