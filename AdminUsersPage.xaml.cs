using BakeryApp;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bakery
{
    public partial class AdminUsersPage : Page
    {
        private readonly ПекарняEntities _context;

        public AdminUsersPage()
        {
            InitializeComponent();
            _context = new ПекарняEntities();
            LoadUsers();
        }

        // Загрузка списка пользователей в DataGrid
        private void LoadUsers()
        {
            try
            {
                UsersDataGrid.ItemsSource = _context.Пользователи.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Отображение или скрытие сообщения
        private void ShowSelectionMessage(bool isVisible)
        {
            UserSelectionMessage.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        // Добавление нового пользователя
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            // Ищем главное окно и получаем ссылку на Frame
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.MainFrame.Navigate(new AddUserPage());
            }
            else
            {
                MessageBox.Show("Ошибка: Главное окно не найдено!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Удаление выбранного пользователя
        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is Пользователи selectedUser)
            {
                _context.Пользователи.Remove(selectedUser);
                _context.SaveChanges();
                LoadUsers(); // Перезагружаем список пользователей
            }
            else
            {
                ShowSelectionMessage(true); // Показываем сообщение
            }
        }

        // Редактирование выбранного пользователя
        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is Пользователи selectedUser)
            {
                NavigationService.Navigate(new EditUserPage(_context, selectedUser));
            }
            else
            {
                ShowSelectionMessage(true); // Показываем сообщение
            }
        }
    }
}
