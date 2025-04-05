using System.Windows;
using System.Windows.Controls;

namespace Bakery
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password;

            var authService = new AuthService();
            var user = authService.Authenticate(username, password); // Получаем объект пользователя

            if (user == null)
            {
                ErrorTextBlock.Text = "Неверный логин или пароль!";
                ErrorTextBlock.Visibility = Visibility.Visible;
                return;
            }

            ErrorTextBlock.Visibility = Visibility.Collapsed;

            // Передаём авторизованного пользователя в MainPage
            var mainPage = new MainPage(user);
            NavigationService.Navigate(mainPage);
        }
    }
}
