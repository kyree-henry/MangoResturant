using System.Text;

namespace Mango.UI.Data.Entities
{
    public class CacheData
    {
        public Guid Id { get; set; }
        public string? OwnerId { get; set; }
        public string? Key { get; set; }
        public string? Tag { get; set; }
        public byte[]? Data { get; set; }

        public string? Content => Data == null ? null : Encoding.Default.GetString(Data);
    }
}
