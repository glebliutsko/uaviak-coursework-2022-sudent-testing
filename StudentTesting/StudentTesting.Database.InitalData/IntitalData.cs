using StudentTesting.Database.Models;

namespace StudentTesting.Database.InitalData
{
    static class IntitalData
    {
        public static readonly User[] Users =
        {
            new User
            {
                Login = "d.popova",
                PasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
                FullName = "Попова Дарья Юрьевна",
                DocumentNumber = "71274",
                Role = UserRole.TEACHER
            },
            new User
            {
                Login = "m.borisov",
                PasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
                FullName = "Борисов Матвей Константинович",
                DocumentNumber = "52211",
                Role = UserRole.TEACHER
            },
            new User
            {
                Login = "d.litvinov",
                PasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
                FullName = "Литвинов Дмитрий Александрович",
                DocumentNumber = "943216",
                Role = UserRole.TEACHER
            },
            new User
            {
                Login = "a.zhukov",
                PasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
                FullName = "Жуков Алексей Александрович",
                DocumentNumber = "864312",
                Role = UserRole.TEACHER
            },
            new User
            {
                Login = "g.rusakov",
                PasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
                FullName = "Русаков Георгий Владимирович",
                DocumentNumber = "13813",
                Role = UserRole.STUDENT
            },
            new User
            {
                Login = "s.moiseeva",
                PasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
                FullName = "Моисеева Софья Ивановна",
                DocumentNumber = "925021",
                Role = UserRole.STUDENT
            },
            new User
            {
                Login = "s.petrova",
                PasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
                FullName = "Петрова Софья Максимовна",
                DocumentNumber = "884112",
                Role = UserRole.STUDENT
            },
            new User
            {
                Login = "a.denisova",
                PasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
                FullName = "Денисова Арина Марковна",
                DocumentNumber = "723612",
                Role = UserRole.STUDENT
            },
            new User
            {
                Login = "a.ivanov",
                PasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
                FullName = "Иванов Артём Артурович",
                DocumentNumber = "723612",
                Role = UserRole.STUDENT
            },
            new User
            {
                Login = "a.novikov",
                PasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
                FullName = "Новиков Алексей Тимурович",
                DocumentNumber = "455116",
                Role = UserRole.STUDENT
            }
        };

        public static readonly Group[] Group =
        {
            new Group
            {
                Number = "19ис-1",
                Students = new User[] { Users[4], Users[5], Users[6] }
            },
            new Group
            {
                Number = "19адс1",
                Students = new User[] { Users[7], Users[8], Users[9] }
            }
        };
    }
}
