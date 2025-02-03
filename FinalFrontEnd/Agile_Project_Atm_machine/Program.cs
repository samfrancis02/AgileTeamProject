namespace Agile_Project_Atm_machine
{
    internal static class Program
    {
        public static HttpClient HttpClient { get; private set; }

        [STAThread]
        static void Main()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5037/api/atmAPI/") // Replace with your API URL
            };

            ApplicationConfiguration.Initialize();
            Application.Run(new insertCard());
        }
    }

}