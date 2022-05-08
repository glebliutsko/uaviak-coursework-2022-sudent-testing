using StudentTesting.Database;

namespace StudentTesting.Application.Database
{
    public static class DbContextKeeper
    {
        public static bool IsConnected => Saved != null;
        public static StudentDbContext Saved { get; private set; }

        private static bool CheckAndSaveConnection(StudentDbContext context)
        {
            if (!context.Database.CanConnect())
                return false;

            if (IsConnected)
                ConnectionClose();

            Saved = context;
            return true;
        }

        public static bool ConnectionOpen(string ip, string user, string password, string database) =>
            CheckAndSaveConnection(new StudentDbContext(ip, user, password, database));

        public static bool ConnectionOpen(string ip, string database) =>
            CheckAndSaveConnection(new StudentDbContext(ip, database));

        public static void ConnectionClose()
        {
            if (!IsConnected)
                return;

            Saved.Dispose();
            Saved = null;
        }
    }
}
