using MediatR;

namespace Restaurants.Application.Users.Commands.AssignUserRole
{
    public class AssignUserRoleCommand : IRequest
    {
        public string UserEmail { get; set; }
        public string RoleName { get; set; }

        public AssignUserRoleCommand(string userEmail,string roleName)
        {
            this.UserEmail = userEmail;
            this.RoleName = roleName;   
        }
    }
}
