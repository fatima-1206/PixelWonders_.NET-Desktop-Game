namespace PixelWonders
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            DatabaseManager dbManager = new DatabaseManager("database.db");
            dbManager.InitializeDatabase();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new Home());
            //Application.Run(new PaletteForm());  uncomment this and comment the line above to view the palette functionality

            // Application.Run(new Menu2());
        }
    }
}
