using Bakery;
using System;
using System.Windows;

namespace BakeryApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                // Устанавливаем начальную страницу в Frame
                mainWindow.MainFrame.Navigate(new LoginPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }
    }
}
