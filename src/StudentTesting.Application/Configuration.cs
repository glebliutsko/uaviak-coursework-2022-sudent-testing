namespace StudentTesting.Application
{
    // Win10Virt
    /*static class Configuration
    {
        public const string ADDRESS_DB = "10.0.0.2";
        public const string DATABASE = "StudentTesting";

        public const bool INTEGRATED_SECURITY = false;
        public const string USER_DB = "sa";
        public const string PASSWORD_DB = "R1409p1209";
    }*/

    // RabComp
    /*static class Configuration
    {
        public const string ADDRESS_DB = @"localhost\SQLEXPRESS";
        public const string DATABASE = "StudentTesting";

        public const bool INTEGRATED_SECURITY = true;
        public const string USER_DB = "";
        public const string PASSWORD_DB = "";
    }*/

    static class Configuration
    {
        public const string ADDRESS_DB = @"(LocalDb)\MSSQLLocalDB";
        public const string DATABASE = "StudentsTesting";

        public const bool INTEGRATED_SECURITY = true;
        public const string USER_DB = "sa";
        public const string PASSWORD_DB = "R1409p1209";
    }
}
