using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ShareCare.App.Extensions
{
    public static class UserExtensions
    {
        public static string GetEmail(this HttpContext context)
        {
            return context?.User.FindFirst(ClaimTypes.Email).Value;
        }

        public static string GetFullName(this HttpContext context)
        {
            return context?.User.FindFirst(ClaimTypes.Name).Value;
        }

        public static string GetName(this HttpContext context)
        {
            var fullname = context?.User.FindFirst(ClaimTypes.Name).Value.Split(" ");
            return fullname[0];
        }


        public static string GetRole(this HttpContext context)
        {
            return context?.User.FindFirst(ClaimTypes.Role).Value;
        }

        public static string GetIdentifier(this HttpContext context)
        {
            return context?.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
