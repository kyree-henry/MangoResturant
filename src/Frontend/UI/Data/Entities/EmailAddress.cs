using System.ComponentModel.DataAnnotations;

namespace Mango.UI.Data.Entities
{
    public class EmailAddress
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string Label { get; set; } = default!;
    }


}
