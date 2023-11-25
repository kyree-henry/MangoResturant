using System.ComponentModel.DataAnnotations;

namespace Mango.UI.Data.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string? CountryCode { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public string Label { get; set; } = default!;
    }


}
