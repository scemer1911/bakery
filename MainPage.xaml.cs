// MainPage.xaml.cs
using System.Windows;
using System.Windows.Controls;

namespace Bakery
{
    public partial class MainPage : Page
    {
        private readonly Пользователи _currentUser;

        public MainPage(Пользователи currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            ConfigureMenu();
        }

        private void ConfigureMenu()
        {
            // Скрываем пункты меню в зависимости от роли
            switch (_currentUser.Роли.Название)
            {
                case "Администратор":
                    // Админ видит всё
                    break;
                case "Продавец":
                    UsersItem.Visibility = Visibility.Collapsed;
                    break;
                case "Клиент":
                    UsersItem.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void MenuListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MenuListView.SelectedItem is ListViewItem selectedItem)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Главная":
                        ContentFrame.Navigate(this); // Оставляем текущую страницу
                        break;
                    case "Пользователи":
                        ContentFrame.Navigate(new AdminUsersPage());
                        break;
                    case "Заказы":
                        // Передаем _currentUser в конструктор страницы Заказы
                        ContentFrame.Navigate(new OrdersPage(_currentUser));
                        break;
                    case "Создать заказ":
                        ContentFrame.Navigate(new CreateOrderPage()); // Переход на страницу создания заказа
                        break;
                    case "Выход":
                        var result = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            Application.Current.Shutdown();
                        }
                        break;
                }
            }
        }
    }
}
