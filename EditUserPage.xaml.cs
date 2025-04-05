using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bakery
{
    public partial class EditUserPage : Page
    {
        private readonly ПекарняEntities _context;
        private readonly Пользователи _selectedUser;

        public EditUserPage(ПекарняEntities context, Пользователи selectedUser)
        {
            InitializeComponent();
            _context = context;
            _selectedUser = selectedUser;
            LoadRoles();
            LoadUserData();
        }


        // Загрузка ролей в ComboBox
        private void LoadRoles()
        {
            var roles = _context.Роли.ToList();
            RoleComboBox.ItemsSource = roles;
            RoleComboBox.DisplayMemberPath = "Название"; // Название роли для отображения
            RoleComboBox.SelectedValuePath = "ID_Роли"; // Значение роли для использования
        }

        // Загрузка данных выбранного пользователя
        private void LoadUserData()
        {
            // Заполняем поля данными пользователя
            UsernameTextBox.Text = _selectedUser.Логин;
            NameTextBox.Text = _selectedUser.Имя;
            PasswordBox.Password = ""; // Пароль не показываем, можно оставить пустым

            // Выбираем текущую роль пользователя
            var currentRole = _selectedUser.Роли;
            RoleComboBox.SelectedItem = currentRole;
        }

        // Сохранение изменений
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string name = NameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(name) || RoleComboBox.SelectedItem is not Роли selectedRole)
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            _selectedUser.Логин = username;
            _selectedUser.Имя = name;
            _selectedUser.ID_Роли = selectedRole.ID_Роли;

            // Если пароль был изменен, обновляем его
            if (!string.IsNullOrEmpty(PasswordBox.Password))
            {
                _selectedUser.Пароль_Хэш = new AuthService().ComputeSha256Hash(PasswordBox.Password);
            }

            _context.SaveChanges();
            MessageBox.Show("Данные пользователя обновлены.");
            NavigationService.GoBack(); // Возвращаемся на страницу пользователей
        }

        // Отмена редактирования и возврат
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
