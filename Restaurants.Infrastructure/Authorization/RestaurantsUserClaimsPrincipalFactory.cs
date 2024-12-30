using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Entities;
using System.Security.Claims;


namespace Restaurants.Infrastructure.Authorization
{
    public class RestaurantsUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IOptions<IdentityOptions> options;

        public RestaurantsUserClaimsPrincipalFactory
        (
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IOptions<IdentityOptions> options
        ) : base(userManager, roleManager, options)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.options = options;
        }

        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
    
            var id = await GenerateClaimsAsync(user);
            if (user.Nationality != null)
            {
                id.AddClaim(new Claim(AppClaimTypes.Nationality, user.Nationality));
            }
            if (user.DateOfBirth != null)
            {
                id.AddClaim(new Claim(AppClaimTypes.DateOfBirth, user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
            }
            //返回一个 ClaimsPrincipal，用于后续的身份验证和授权操作
            return new ClaimsPrincipal(id);
        }
    }
}
