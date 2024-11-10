namespace TechChallenge.Application.UseCases.DeleteContact
{
    public sealed record DeleteContactResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid IdArea { get; set; }
    }
}
