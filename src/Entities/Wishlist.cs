#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class Wishlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
