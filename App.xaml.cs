namespace APPUCENM
{
    public partial class App : Application
    {

        static Controllers.PersonasController database;

        public static Controllers.PersonasController Database
        {
            get 
            {
                if (database == null)
                {
                    database = new Controllers.PersonasController();
                }

                return database;
            }
            
        }


        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
