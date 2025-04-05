using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bakery
{
    public partial class CreateOrderPage : Page
    {
        private readonly ПекарняEntities _context;
        private List<Продукты> _products;

        public CreateOrderPage()
        {
            InitializeComponent();
            _context = new ПекарняEntities();
            LoadProducts();
        }

        private void LoadProducts()
        {
            _products = _context.Продукты.ToList();

            // Добавляем поле Quantity для ввода
            foreach (var product in _products)
            {
                product.Quantity = 0;
            }

            ProductsDataGrid.ItemsSource = _products;
        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var customerName = CustomerNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Введите имя клиента.");
                return;
            }

            var selectedProducts = _products.Where(p => p.Quantity > 0).ToList();
            if (!selectedProducts.Any())
            {
                MessageBox.Show("Выберите хотя бы один продукт и укажите количество.");
                return;
            }

            try
            {
                var order = new Заказы
                {
                    Дата_заказа = DateTime.Now,
                    Статус = "В обработке",
                    Сумма = selectedProducts.Sum(p => p.Quantity * p.Цена),
                    Имя_клиента = customerName
                };

                _context.Заказы.Add(order);
                _context.SaveChanges();

                foreach (var product in selectedProducts)
                {
                    var orderProduct = new Заказанные_товары
                    {
                        ID_Заказа = order.ID_Заказа,
                        ID_Продукта = product.ID_Продукта,
                        Количество = product.Quantity
                    };

                    _context.Заказанные_товары.Add(orderProduct);
                }

                _context.SaveChanges();

                MessageBox.Show("Заказ успешно создан!");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании заказа: {ex.Message}");
            }
        }
    }
}
