namespace CleanArchitecture.Template.Infrastructure.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
