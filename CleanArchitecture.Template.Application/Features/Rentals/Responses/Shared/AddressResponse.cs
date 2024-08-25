namespace CleanArchitecture.Template.Application.Features.Rentals.Responses.Shared
{
    public sealed class AddressResponse
    {
        public string? Country { get; init; }
        public string? Department { get; init; }
        public string? Province { get; init; }
        public string? Street { get; init; }
    }
}
