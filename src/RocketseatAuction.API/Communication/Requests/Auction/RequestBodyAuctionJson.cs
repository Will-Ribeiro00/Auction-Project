namespace RocketseatAuction.API.Communication.Requests.Auction
{
    public class RequestBodyAuctionJson
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
