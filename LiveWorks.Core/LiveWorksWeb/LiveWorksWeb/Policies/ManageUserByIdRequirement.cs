// ======================================
// Author: liveworks  
// Email:  info@liveworks.com
// Copyright (c) 2017 www.liveworks.com
// 
// ==> Gun4Hire: contact@liveworks.com
// ======================================

using DAL.Core;
using LiveWorksWeb.Helpers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LiveWorksWeb.Policies
{
    public class ManageUserByIdRequirement : IAuthorizationRequirement
    {

    }


    public class ManageUserByIdHandler : AuthorizationHandler<ManageUserByIdRequirement, string>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageUserByIdRequirement requirement, string userId)
        {
            if (context.User.HasClaim(CustomClaimTypes.Permission, ApplicationPermissions.ManageUsers) || GetIsSameUser(context.User, userId))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }


        private bool GetIsSameUser(ClaimsPrincipal user, string userId)
        {
            return Utilities.GetUserId(user) == userId;
        }
    }
}
