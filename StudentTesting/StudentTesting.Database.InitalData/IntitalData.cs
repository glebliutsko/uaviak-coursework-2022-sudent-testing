using StudentTesting.Database.Models;
using StudentTesting.SecurityPassword;
using System.Security.Cryptography;

namespace StudentTesting.Database.InitalData
{
    static class IntitalData
    {
        private static readonly PasswordHasher passwordHasher = new PasswordHasher(SHA256.Create(), new RandomizedSaltGenerator(30));

        public static readonly SaltedHash[] passwords = new SaltedHash[]
        {
            passwordHasher.ComputeSaltedHashWithRandomSalt("password"),
            passwordHasher.ComputeSaltedHashWithRandomSalt("password"),
            passwordHasher.ComputeSaltedHashWithRandomSalt("password"),
            passwordHasher.ComputeSaltedHashWithRandomSalt("password"),
            passwordHasher.ComputeSaltedHashWithRandomSalt("password"),
            passwordHasher.ComputeSaltedHashWithRandomSalt("password"),
            passwordHasher.ComputeSaltedHashWithRandomSalt("password"),
            passwordHasher.ComputeSaltedHashWithRandomSalt("password"),
            passwordHasher.ComputeSaltedHashWithRandomSalt("password"),
            passwordHasher.ComputeSaltedHashWithRandomSalt("password")
        };

        public static readonly User[] Users =
        {
            new User
            {
                Login = "d.popova",
                PasswordHash = passwords[0].Hash,
                Salt = passwords[0].Salt,
                FullName = "Попова Дарья Юрьевна",
                DocumentNumber = "71274",
                Role = UserRole.TEACHER
            },
            new User
            {
                Login = "m.borisov",
                PasswordHash = passwords[1].Hash,
                Salt = passwords[1].Salt,
                FullName = "Борисов Матвей Константинович",
                DocumentNumber = "52211",
                Role = UserRole.TEACHER
            },
            new User
            {
                Login = "d.litvinov",
                PasswordHash = passwords[2].Hash,
                Salt = passwords[2].Salt,
                FullName = "Литвинов Дмитрий Александрович",
                DocumentNumber = "943216",
                Role = UserRole.TEACHER
            },
            new User
            {
                Login = "a.zhukov",
                PasswordHash = passwords[3].Hash,
                Salt = passwords[3].Salt,
                FullName = "Жуков Алексей Александрович",
                DocumentNumber = "864312",
                Role = UserRole.TEACHER
            },
            new User
            {
                Login = "g.rusakov",
                PasswordHash = passwords[4].Hash,
                Salt = passwords[4].Salt,
                FullName = "Русаков Георгий Владимирович",
                DocumentNumber = "13813",
                Role = UserRole.STUDENT
            },
            new User
            {
                Login = "s.moiseeva",
                PasswordHash = passwords[5].Hash,
                Salt = passwords[5].Salt,
                FullName = "Моисеева Софья Ивановна",
                DocumentNumber = "925021",
                Role = UserRole.STUDENT
            },
            new User
            {
                Login = "s.petrova",
                PasswordHash = passwords[6].Hash,
                Salt = passwords[6].Salt,
                FullName = "Петрова Софья Максимовна",
                DocumentNumber = "884112",
                Role = UserRole.STUDENT
            },
            new User
            {
                Login = "a.denisova",
                PasswordHash = passwords[7].Hash,
                Salt = passwords[7].Salt,
                FullName = "Денисова Арина Марковна",
                DocumentNumber = "723612",
                Role = UserRole.STUDENT
            },
            new User
            {
                Login = "a.ivanov",
                PasswordHash = passwords[8].Hash,
                Salt = passwords[8].Salt,
                FullName = "Иванов Артём Артурович",
                DocumentNumber = "723612",
                Role = UserRole.STUDENT
            },
            new User
            {
                Login = "a.novikov",
                PasswordHash = passwords[9].Hash,
                Salt = passwords[9].Salt,
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
