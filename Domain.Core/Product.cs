using System.Text.Json.Serialization;

namespace RobolineTest.Domain.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public ProductCategory Category { get; set; }

        [JsonIgnore]
        public int CategoryId { get; set; }
    }
}
