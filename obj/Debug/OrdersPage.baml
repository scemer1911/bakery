   M S B A M L   `   `   `  ����
  Bakery    Bakery.OrdersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$!  Список заказов��5      .��5      � .+�5   
   �� $!��Список заказов��6   $��20(�6*   $
��Bold"�68   $��
10,0,10,10q�6J   �� 5
   
   -   5         ��Name$ OrderSelectionMessage��5
      $!��Выберите заказ��63   
���  ��$��Center=�6Z   $	��Top=�6w   $y�	Collapsed=�6�   $��0,24,0,0q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ OrdersDataGrid��5         AutoGenerateColumns .     
IsReadOnly . $��10,45,10,45q�6Y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID_Заказа+  5      $ Дата��6%    63   �� *Дата_заказа+  5      $ Статус��6%    65   �� *Статус+  5      $ 
Сумма��6%    64   �� *
Сумма+5      �� 5   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��Bottom=�6I   $��10q�6d   .+�5      �� -   5        $*��$Принять в обработку��5      $��0,0,10,0q�6N   �� 5      -   5        $,��&Отметить как готовый��5      $��0,0,10,0q�6N   �� 5      -   5        $��Выдать заказ��5      6,   5      5      5      