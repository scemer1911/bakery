using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bakery
{
    public partial class EditOrderWindow : Window
    {
        private readonly ПекарняEntities _context;
        private readonly Заказы _order;

        public EditOrderWindow(Заказы order)
        {
            InitializeComponent();
            _context = new ПекарняEntities();
            _order = order;

            // Инициализация окна данными заказа
            StatusComboBox.SelectedItem = StatusComboBox.Items
                .Cast<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == order.Статус);

            OrderDatePicker.SelectedDate = order.Дата_заказа;
        }

        // Обработчик для кнопки "Сохранить"
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Обновление данных заказа
            _order.Статус = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            _order.Дата_заказа = OrderDatePicker.SelectedDate ?? _order.Дата_заказа;

            _context.SaveChanges();
            MessageBox.Show("Изменения сохранены.");

            // Закрытие окна
            this.DialogResult = true;
            this.Close();
        }

        // Обработчик для кнопки "Отменить"
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
