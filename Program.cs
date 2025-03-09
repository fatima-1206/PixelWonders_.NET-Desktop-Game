namespace PixelWonders
{
    internal static class Program
    {
        // Make dbManager a static variable so it can be accessed globally
        public static DatabaseManager dbManager = null!;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            //  Ensure dbManager is initialized before any form is launched
            dbManager = new DatabaseManager("PixelWonders.db");
            dbManager.InitializeDatabase();

            Application.Run(new Home()); // or Login Form
        }
    }
}
