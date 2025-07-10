using HerreraRExamenFinalRegistros.Repositories;

namespace HerreraRExamenFinalRegistros
{
    public partial class App : Application
    {
        public static ModelRepository ModelRepository { get; private set; }

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "proyectos.db3");

            ModelRepository = new ModelRepository(dbPath);

            MainPage = new AppShell();
        }
    }
}
