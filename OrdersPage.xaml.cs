using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bakery
{
    public partial class OrdersPage : Page
    {
        private readonly Пользователи _currentUser;
        private readonly ПекарняEntities _context;
        public OrdersPage(Пользователи currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _context = new ПекарняEntities();
            LoadOrders();
        }

        private void LoadOrders()
        {
            // Здесь загружаем заказы, возможно фильтруем их в зависимости от роли пользователя
            if (_currentUser.Роли.Название == "Продавец")
            {
                // Загружаем заказы для продавца, например, только те, которые в обработке
                OrdersDataGrid.ItemsSource = _context.Заказы.Where(o => o.Статус == "В обработке").ToList();
            }
            else
            {
                // Для других ролей, например, клиента, можем показывать все заказы
                OrdersDataGrid.ItemsSource = _context.Заказы.ToList();
            }
        }

        // Проверка выбранного заказа перед изменением его статуса
        private void CheckSelectedOrder()
        {
            if (OrdersDataGrid.SelectedItem == null)
            {
                OrderSelectionMessage.Visibility = Visibility.Visible;
            }
            else
            {
                OrderSelectionMessage.Visibility = Visibility.Collapsed;
            }
        }

        private void ProcessOrder_Click(object sender, RoutedEventArgs e)
        {
            CheckSelectedOrder();
            if (OrdersDataGrid.SelectedItem is Заказы selectedOrder)
            {
                // Логика для обработки заказа
                selectedOrder.Статус = "В обработке";
                _context.SaveChanges();
                LoadOrders(); // Обновляем список заказов
            }
        }

        private void MarkAsReady_Click(object sender, RoutedEventArgs e)
        {
            CheckSelectedOrder();
            if (OrdersDataGrid.SelectedItem is Заказы selectedOrder)
            {
                // Логика для отметки заказа как готового
                selectedOrder.Статус = "Готово";
                _context.SaveChanges();
                LoadOrders(); // Обновляем список заказов
            }
        }

        private void MarkAsIssued_Click(object sender, RoutedEventArgs e)
        {
            CheckSelectedOrder();
            if (OrdersDataGrid.SelectedItem is Заказы selectedOrder)
            {
                // Логика для отметки заказа как выданного
                selectedOrder.Статус = "Выдано";
                _context.SaveChanges();
                LoadOrders(); // Обновляем список заказов
            }
        }

        // Обработчик двойного клика по заказу
        private void OrdersDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is Заказы selectedOrder)
            {
                // Открываем новое окно с деталями заказа
                var orderDetailsWindow = new OrderDetailsWindow(selectedOrder);
                orderDetailsWindow.ShowDialog();
            }
        }
    }
}
