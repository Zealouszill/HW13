using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using HW11Database;
using HW11Types;
using SharedLogic.ViewModel;

namespace HW11.Avalonia
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataStorage testStorage = new SqliteDataStore();
            PotentialRepository testRepo = new PotentialRepository(testStorage);
            BuildAvaloniaApp().Start<MainWindow>(() => new MainViewModel(testRepo));
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();
    }
}
