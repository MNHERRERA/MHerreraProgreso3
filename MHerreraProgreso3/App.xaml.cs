using MHerreraProgreso3.Services;
using MHerreraProgreso3.Views;

namespace MHerreraProgreso3
{
    public partial class App : Application
    {
        public static ProductoDatabase ProductoDB { get; private set; }

        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "productos.db3");
            ProductoDB = new ProductoDatabase(dbPath);
            MainPage = new NavigationPage(ProductosPage);
        }
    }
}
