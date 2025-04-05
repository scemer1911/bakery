using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bakery
{
    public partial class AddUserPage : Page
    {
        private readonly ПекарняEntities _context;

        public AddUserPage()
        {
            InitializeComponent();
            _context = new ПекарняEntities();
            LoadRoles();
        }

        // Загрузка ролей в ComboBox
        private void LoadRoles()
        {
            var roles = _context.Роли.ToList();

            RoleComboBox.Items.Clear(); // Очистка перед установкой ItemsSource

            RoleComboBox.ItemsSource = roles;
            RoleComboBox.DisplayMemberPath = "Название"; // название роли для отображения
            RoleComboBox.SelectedValuePath = "ID_Роли"; // значение роли для использования
        }

        // Добавление пользователя в базу данных
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string Name = NameTextBox.Text.Trim();
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && RoleComboBox.SelectedItem is Роли selectedRole)
            {
                var newUser = new Пользователи
                {
                    Имя = Name,
                    Логин = username,
                    Пароль_Хэш = new AuthService().ComputeSha256Hash(password),
                    ID_Роли = selectedRole.ID_Роли // Сохраняем ID роли
                };

                try
                {
                    _context.Пользователи.Add(newUser);
                    _context.SaveChanges();
                    MessageBox.Show("Пользователь добавлен.");
                    NavigationService.GoBack();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Ошибка: {validationError.PropertyName} - {validationError.ErrorMessage}");
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }
        }

        // Отмена добавления пользователя
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
