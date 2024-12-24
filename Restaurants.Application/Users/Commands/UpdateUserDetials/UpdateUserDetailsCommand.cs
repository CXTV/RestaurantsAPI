using MediatR;

namespace Restaurants.Application.Users.Commands.UpdateUserDetials
{
    public class UpdateUserDetailsCommand : IRequest
    {
        public DateOnly? DateOfBirth { get; set; }
        public string? Nationality { get; set; }

        public UpdateUserDetailsCommand(DateOnly dateOfBirth, string nationality)
        {
            DateOfBirth = dateOfBirth;
            Nationality = nationality;
        }
    }
}
