namespace Transactions.Api.Dto
{
    public class DebitRequest
    {
        public double Value { get; set; }
        public string AccountId { get; set; }
        public string Description { get; set; }
    }
}