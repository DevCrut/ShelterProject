using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShelterProject.Models
{
    public class ApplicationUser: IdentityUser
    {
        public DateTime? DateCreated { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Ownership> SheltersOwning {  get; set; } 
    }
}
