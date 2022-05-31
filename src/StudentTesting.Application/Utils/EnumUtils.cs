using DbModel = StudentTesting.Database.Models;
using System;

namespace StudentTesting.Application.Utils
{
    public static class EnumUtils
    {
        private static Lazy<DbModel.UserRole[]> _rolesLazy = new Lazy<DbModel.UserRole[]>(() => Enum.GetValues<DbModel.UserRole>());

        public static DbModel.UserRole[] Roles => _rolesLazy.Value;
    }
}
