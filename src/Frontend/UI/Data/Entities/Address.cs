namespace Mango.UI.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public bool IsMain { get; set; }
        public string Street { get; set; } = default!;
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

        public virtual List<Contact>? PhoneNumbers { get; set; }
    }
}
