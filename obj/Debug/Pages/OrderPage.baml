   M S B A M L   `   `   `  ����B  >Lombard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Lombard.PagesLombard.Pages  5          Lombard.Pages.OrderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Lombard.Pages     5      -   5          N� Title$  	OrderPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��40 �6   6*   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridUslugi��5      $��0��6+      AutoGenerateColumns .     
IsReadOnly .    	RowHeight$ 30Q�5         SelectionMode$ Single=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер заказа��6A   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 5* 6W   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *	Deal_id+6d     5      $ Номер заказа��6H   $	 5* 6^   
 6%   �� *Item.Item_Name+6k     5      $, &Дата создания заказа��6]   $	 5* 6{   
 6%   �� *Date+ �� StringFormat$ {0:dd/MM/yyyy}��6�     5      $ Заказчик��6D   $		 10* 6V   
 6%   �� *
Client.FIO+6d     5      $ Цена��6>   $	 2* 6L   
 6%   �� *Cost+6Y   5%      � 5&   
   $��1��6   
���/���67   �� 5)   
   -   5         ��Name$ BtnDeleteOrder��5)      $��1��6)   $	��100��66   $��Right=�6B   $��3q�6^   $��Удалить��6i   6�   5*      5+      