using CleanArchitecture.Template.Domain.Abstractions;

namespace CleanArchitecture.Template.Domain.DomainModels.Users
{
    public static class UserErros
    {
        public static Error NotFound = new
        (
            "User.Found",
            "User with provided Id does not exist"
        );

        public static Error InvalidCredentials = new
        (
            "User.InvalidCredentials",
            "Provided credentials are not correct"
        );
    }
}
