using RocketseatAuction.API.Enums;

namespace RocketseatAuction.API.Communication.Requests.Item
{
    public class RequestBodyItemJson
    {
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public Condition Condition { get; set; }
        public decimal BasePrice { get; set; }
    }
}
