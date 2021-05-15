﻿using Application.Common.Dtos;

using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName,string avatar);

        Task<Result> DeleteUserAsync(string userId);
        Task<bool> IsUserExistAsync(string userName);
        Task<IEnumerable< UserDto>> Get5lastUserRegisterOnSite();



    }
}
