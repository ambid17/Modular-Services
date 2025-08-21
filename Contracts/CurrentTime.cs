namespace Contracts
{
    public class CurrentTime
    {
        // Init here only allows setter during object initialization
        // This is a recommendation from MassTransit to ensure immutability
        public string Value { get; init; } = string.Empty;
    }
}
