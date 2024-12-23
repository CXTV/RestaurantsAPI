using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands.UpdateUserDetials
{
    public class UpdateUserDetailsCommandHandler : IRequestHandler<UpdateUserDetailsCommand>
    {
        private readonly ILogger<UpdateUserDetailsCommandHandler> logger;
        private readonly IUserContext userContext;
        //是 ASP.NET Core Identity 提供的一个接口，定义了用于管理用户实体的基础存储操作。它是实现用户数据存储和管理的核心接口之一
        private readonly IUserStore<User> userStore;

        public UpdateUserDetailsCommandHandler
        (
            ILogger<UpdateUserDetailsCommandHandler> logger,
            IUserContext userContext,
            IUserStore<User> userStore
        )
        {
            this.logger = logger;
            this.userContext = userContext;
            this.userStore = userStore;
        }

        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Update user details command handler");
            //1.获取当前用户
            var user = userContext.GetCurrentUser();
            //2.根据用户Id查找用户
            var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);

            if (dbUser == null)
            {
                throw new NotFoundException("User not found");
            }
            //3.更新用户信息
            dbUser.DateOfBirth = request.DateOfBirth;
            dbUser.Nationality = request.Nationality;

            //4.更新数据库
            await userStore.UpdateAsync(dbUser, cancellationToken);
        }
    }
}
