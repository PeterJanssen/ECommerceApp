using Core.Entities.AccountEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipleWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = ClaimsPrincipleExtensions.RetrieveEmailFromPrincipal(user);

            return await input.Users
            .SingleOrDefaultAsync(x => x.Email == email);
        }

        public static async Task<AppUser> FindUserByClaimsPrincipleAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = ClaimsPrincipleExtensions.RetrieveEmailFromPrincipal(user);

            return await input.Users
            .SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}