using CleanArchitecture.Template.Domain.Abstractions;
using CleanArchitecture.Template.Domain.DomainEvents.Users;
using CleanArchitecture.Template.Domain.Enums.Users;
using CleanArchitecture.Template.Domain.ValueObjects.Users;

namespace CleanArchitecture.Template.Domain.DomainModels.Users
{
    public sealed class User : Entity
    {
        private User
        (
            Guid id,
            Name? name,
            Surname? surname,
            Email? email,
            string documentId,
            Gender? gender,
            DateTime? birthDate
        ) : base(id)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DocumentId = documentId;
            Gender = gender;
            BirthDate = birthDate;
        }

        public Name Name { get; private set; }
        public Surname Surname { get; private set; }
        public Email Email { get; private set; }
        public string DocumentId { get; private set; }
        public Gender? Gender { get; private set; }
        public DateTime? BirthDate { get; private set; }


        public static User Create(
            Name? name,
            Surname? surname,
            Email? email,
            string documentId,
            Gender? gender,
            DateTime? birthDate
        )
        {
            var user = new User(Guid.NewGuid(), name, surname, email, documentId, gender, birthDate);

            user.RaiseDomainEvent(new CreateUserDomainEvent(user.Id));

            return user;
        }
    }
}
