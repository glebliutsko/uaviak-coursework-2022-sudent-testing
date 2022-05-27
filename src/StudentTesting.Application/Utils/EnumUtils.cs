using DbModel = StudentTesting.Database.Models;
using System;

namespace StudentTesting.Application.Utils
{
    public static class EnumUtils
    {
        private static Lazy<DbModel.UserRole[]> _rolesLazy = new Lazy<DbModel.UserRole[]>(() => Enum.GetValues<DbModel.UserRole>());
        private static Lazy<DbModel.TypeQuestion[]> _typeQuestionLazy = new Lazy<DbModel.TypeQuestion[]>(() => Enum.GetValues<DbModel.TypeQuestion>());

        public static DbModel.UserRole[] Roles => _rolesLazy.Value;
        public static DbModel.TypeQuestion[] TypeQuestions => _typeQuestionLazy.Value;
    }
}
