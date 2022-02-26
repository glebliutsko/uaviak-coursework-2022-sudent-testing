using StudentTesting.Database.Models;
using System;

namespace StudentTesting.Application.Utils
{
    public static class ListUserRoles
    {
        public static UserRole[] Roles => Enum.GetValues<UserRole>();
    }
}
