   M S B A M L   `   `   `  ����
  Bakery    Bakery.AdminUsersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$7  1Управление пользователями��5      .��5      � .+�5   
   �� $7��1Управление пользователями��6   $��20(�65   $
��Bold"�6C   $��
10,0,10,10q�6U   �� 5   
   -   5         ��Name$ UserSelectionMessage��5      $/��)Выберите пользователя��62   
���  ��$��Center=�6`   $	��Top=�6}   $y�	Collapsed=�6�   $��0,24,0,0q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ UsersDataGrid��5         AutoGenerateColumns .     
IsReadOnly .    CanUserAddRows .  $��10,45,10,45q�6o      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID_Пользователя+  5      $ Имя��6%    62   �� *Имя+  5      $ 
Логин��6%    64   �� *
Логин+  5      $ ID Роли��6%    66   �� *ID_Роли+5      �� 5   
   -   5        $/��)Добавить пользователя��5      $
��Left=�61   $��Bottom=�6L   $��	10,0,0,10q�6g   $	��150��6z   6�   �� 5   
   -   5        $-��'Удалить пользователя��5      $
��Left=�60   $��Bottom=�6K   $��
170,0,0,10q�6f   $	��150��6z   6�   �� 5   
   -   5        $9��3Редактировать пользователя��5      $
��Left=�66   $��Bottom=�6Q   $��
330,0,0,10q�6l   $	��150��6�   6�   5      5      