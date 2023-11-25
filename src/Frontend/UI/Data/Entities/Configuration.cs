namespace Mango.UI.Data.Entities
{
    public class Configuration
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? LogoUrl { get; set; }
        public string? CopyrightYear { get; set; }

        public int HeaderEmailId { get; set; }
        public bool IsActive { get; set; }

        public virtual List<Address>? Addresses { get; set; }
        public virtual List<EmailAddress>? Emails { get; set; }
        public virtual List<Contact>? PhoneNumbers { get; set; }
    }
}
