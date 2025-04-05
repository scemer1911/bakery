using System.Windows;

namespace Bakery
{
    public partial class OrderDetailsWindow : Window
    {
        public OrderDetailsWindow(Заказы order)
        {
            InitializeComponent();

            OrderID.Text = order.ID_Заказа.ToString();
            OrderDate.Text = order.Дата_заказа.ToString();
            OrderStatus.Text = order.Статус;
            OrderAmount.Text = order.Сумма.ToString("C");
        }
    }
}
